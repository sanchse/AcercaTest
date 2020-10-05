using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.DTOs.Vehicles {
  public class ModifyVehicleDto {
    public string OrderNumber { get; set; }
    public string ChassisNumber { get; set; }
    public string Model { get; set; }
    public string NumberPlate { get; set; }
    public DateTime DeliveryDate;
  }
}
