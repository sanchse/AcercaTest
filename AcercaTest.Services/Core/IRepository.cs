using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.Core {
  public interface IRepository<T> where T: class {
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> Get(int pageNumber, int pageSize);
    T GetById(object id);
  }
}
