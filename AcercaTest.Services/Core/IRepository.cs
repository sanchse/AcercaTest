using AcercaTest.Services.Model;
using AcercaTest.Services.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.Core {
  public interface IRepository<T> where T: class {
    void Insert(T entity);
    void Update(T entity);
    bool Delete(object id);
    ItemsResult<Vehicle> Get(int pageNumber, int pageSize);
    T GetById(object id);
  }
}
