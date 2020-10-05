using System;
using System.Collections.Generic;
using AcercaTest.Services.Core;
using AcercaTest.Services.DTOs.Vehicles;
using AcercaTest.Services.Model;
using AcercaTest.Services.Vehicles;

namespace AcercaTest.Services.Services {
  public interface IVehiclesService {
    Vehicle Create(CreateVehicleDto createVehicleDto);
    bool Delete(Guid id);
    Vehicle Modify(Guid id, ModifyVehicleDto modifyVehicleDto);
    ItemsResult<Vehicle> Search(SearchFilterVehicleDto searchFilter);
    Vehicle GetVehicleById(Guid id);
  }
}