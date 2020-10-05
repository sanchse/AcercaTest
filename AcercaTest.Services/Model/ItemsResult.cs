using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.Model {
  public class ItemsResult<T> where T: class {
    public int Total { get; set; }
    public int Count { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public List<T> Items { get; set; }

    public ItemsResult() {
      Items = new List<T>();
    }
  }
}
