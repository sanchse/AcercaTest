using AcercaTest.Services.Core;
using AcercaTest.Services.DTOs.Vehicles;
using AcercaTest.Services.Model;
using AcercaTest.Services.Vehicles;
using System;
using System.Collections.Generic;

namespace AcercaTest.Services.Services {
  public class VehiclesService : IVehiclesService {
    private IRepository<Vehicle> _repository;

    public VehiclesService(IRepository<Vehicle> repository) {
      _repository = repository;
    }

    public Vehicle Create(CreateVehicleDto createVehicleDto) {
      Vehicle newVehicle = Mapping.Mapping.Mapper.Map<Vehicle>(createVehicleDto);
      newVehicle.Id = Guid.NewGuid();

      _repository.Insert(newVehicle);

      return newVehicle;
    }

    public Vehicle Modify(Guid id, ModifyVehicleDto modifyVehicleDto) {
      var vehicle = _repository.GetById((object)id);

      if (vehicle != null) {
        var modifiedVehicle = Mapping.Mapping.Mapper.Map<Vehicle>(modifyVehicleDto);
        modifiedVehicle.Id = id;

        _repository.Update(modifiedVehicle);
        vehicle = modifiedVehicle;
      }

      return vehicle;
    }

    public bool Delete(Guid id) {
      return _repository.Delete(id);
    }

    public ItemsResult<Vehicle> Search(SearchFilterVehicleDto searchFilter) {
      return _repository.Get(searchFilter.pageNumber, searchFilter.pageSize);
    }

    public Vehicle GetVehicleById(Guid id) {
      return _repository.GetById(id);
    }
  }
}
