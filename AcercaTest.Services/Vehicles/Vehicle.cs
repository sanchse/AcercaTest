using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.Vehicles {
  public class Vehicle {
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public string ChassisNumber { get; set; }
    public string Model { get; set; }
    public string NumberPlate { get; set; }
    public DateTime DeliveryDate { get; set; }
  }
}
