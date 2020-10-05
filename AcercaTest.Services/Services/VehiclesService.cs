using AcercaTest.Services.Core;
using AcercaTest.Services.DTOs.Vehicles;
using AcercaTest.Services.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.Services {
  public class VehiclesService {
    private IRepository<Vehicle> _repository;

    public void VehicleService(IRepository<Vehicle> repository) {
      _repository = repository;
    }

    public Vehicle Create(CreateVehicleDto createVehicleDto) {
      Vehicle newVehicle = new Vehicle() {
        Id = Guid.NewGuid(),
        ChassisNumber = createVehicleDto.ChassisNumber,
        DeliveryDate = createVehicleDto.DeliveryDate,
        Model = createVehicleDto.Model,
        NumberPlate = createVehicleDto.NumberPlate,
        OrderNumber = createVehicleDto.OrderNumber
      };

      _repository.Insert(newVehicle);

      return newVehicle;
    }

    public Vehicle Modify(Guid id, ModifyVehicleDto modifyVehicleDto) {
      var vehicle = _repository.GetById((object)id);

      if (vehicle != null) {
        vehicle.
      }

      return vehicle;
    }
  }
}
