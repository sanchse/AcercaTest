using AcercaTest.Services.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.Vehicles {
  public class FileVehicleRepository : IRepository<Vehicle> {
    private const int DEFAULT_PAGE_SIZE = 10;
    private readonly string _filePath = Directory.GetCurrentDirectory() + "/vehicles";

    public List<Vehicle> Get(int pageNumber = 0, int pageSize = DEFAULT_PAGE_SIZE) {
      List<Vehicle> result = new List<Vehicle>();

      var files = Directory.GetFiles(_filePath);

      int from = (pageNumber) * pageSize;
      int to = pageSize != 0 ? (pageNumber + 1) * pageSize : files.Length;

      for(int i = from; i < Math.Min(to, files.Length); i++) {
        if (File.Exists(FileName(files[i]))) {
          var text = File.ReadAllText(FileName(files[i]));
          var vehicle = JsonConvert.DeserializeObject<Vehicle>(text);
          result.Add(vehicle);
        }
      }

      return result;
    }

    public Vehicle GetById(object id) {
      string idStringValue = ExtractStringId(id);

      if (idStringValue != null && File.Exists(FileName(idStringValue))) {
        var text = File.ReadAllText(FileName(idStringValue));
        return JsonConvert.DeserializeObject<Vehicle>(text);
      }

      return null;
    }

    public void Insert(Vehicle entity) {
      WriteToFile(entity);
    }

    public void Update(Vehicle entity) {
      WriteToFile(entity);
    }

    public void Delete(object id) {
      string idStringValue = ExtractStringId(id);

      if (idStringValue != null && File.Exists(FileName(idStringValue))) {
        var file = FileName(idStringValue);
        File.Delete(file);
      }
    }

    private string FileName(string id) {
      return $"{_filePath}.{id}.repo";
    }

    private void WriteToFile(Vehicle entity) {
      using (StreamWriter outputFile = new StreamWriter(this.FileName(entity.Id.ToString()), false)) {
        outputFile.WriteLine(JsonConvert.SerializeObject(entity));
      }
    }

    private string ExtractStringId(object id) {
      string result = "";
      try {
        var guid = (Guid)id;
        result = guid.ToString();
      }
      catch (Exception) {
      }

      return result;
    }
  }
}
