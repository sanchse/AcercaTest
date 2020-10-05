using AcercaTest.Services.Core;
using AcercaTest.Services.Model;
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
    private readonly string _filePath;

    public FileVehicleRepository(string baseFilePath) {
      _filePath = baseFilePath;
    }
    public ItemsResult<Vehicle> Get(int pageNumber = 0, int pageSize = DEFAULT_PAGE_SIZE) {
      ItemsResult<Vehicle> result = new ItemsResult<Vehicle>();
      result.PageNumber = pageNumber;
      result.PageSize = pageSize;

      var files = Directory.GetFiles(_filePath);
      result.Total = files.Length;

      int from = (pageNumber) * pageSize;
      int to = pageSize != 0 ? (pageNumber + 1) * pageSize : files.Length;

      for (int i = from; i < Math.Min(to, files.Length); i++) {
        if (File.Exists(files[i])) {
          var text = File.ReadAllText(files[i]);
          var vehicle = JsonConvert.DeserializeObject<Vehicle>(text);
          result.Items.Add(vehicle);
        }
      }

      result.Count = result.Items.Count();

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

    public bool Delete(object id) {
      bool result = false;
      string idStringValue = ExtractStringId(id);

      if (idStringValue != null && File.Exists(FileName(idStringValue))) {
        var file = FileName(idStringValue);
        File.Delete(file);
        result = true;
      }
      return result;
    }

    private string FileName(string id) {
      return $"{_filePath}\\vehicle.{id}.repo";
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
