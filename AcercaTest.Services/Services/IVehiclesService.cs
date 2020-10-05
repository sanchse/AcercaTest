using System;
using System.Collections.Generic;
using AcercaTest.Services.Core;
using AcercaTest.Services.DTOs.Vehicles;
using AcercaTest.Services.Vehicles;

namespace AcercaTest.Services.Services {
  public interface IVehiclesService {
    Vehicle Create(CreateVehicleDto createVehicleDto);
    void Delete(Guid id);
    Vehicle Modify(Guid id, ModifyVehicleDto modifyVehicleDto);
    List<Vehicle> Search(SearchFilterVehicleDto searchFilter);
    Vehicle GetVehicleById(Guid id);
  }
}