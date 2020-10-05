using AcercaTest.Models;
using AcercaTest.Services.DTOs.Vehicles;
using AcercaTest.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using System.Web.Http.Description;

namespace AcercaTest.Controllers {
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class VehiclesController : ApiController {
    private IVehiclesService _vehiclesService;

    public VehiclesController(IVehiclesService vehiclesService) {
      _vehiclesService = vehiclesService;
    }

    /// <summary>
    /// GET the a list of vehicles
    /// </summary>
    /// <returns>
    /// List of vehicles
    /// </returns>
    [HttpGet]
    public IHttpActionResult GetVehicles(int pageNumber = 0, int pageSize = 0) {
      var searchDto = new SearchFilterVehicleDto() {
        pageNumber = pageNumber,
        pageSize = pageSize
      };
      var response = _vehiclesService.Search(searchDto);

      if (response == null) {
        return NotFound();
      }

      var vehiclesList = Mapping.Mapping.Mapper.Map<List<Models.Vehicle>>(response);
      return Ok(vehiclesList);
    }

    /// <summary>
    /// GET a vehicle by Id
    /// </summary>
    /// <param name="id">Id as a Guid format</param>
    /// <returns>The vehicle object</returns>
    [HttpGet]
    public IHttpActionResult GetVehicle(string id) {
      Guid guid = new Guid(id);
      var response = _vehiclesService.GetVehicleById(guid);

      if (response == null) {
        return NotFound();
      }

      var vehicle = AcercaTest.Mapping.Mapping.Mapper.Map<Models.Vehicle>(response);
      return Ok(vehicle);
    }

    /// <summary>
    /// Create a new vehicle
    /// </summary>
    /// <param name="createVehicleDto">Input parameters for the new vehicle (insert in Body)</param>
    /// <returns>The created vehicle</returns>
    [HttpPost]
    public IHttpActionResult Create([FromBody] CreateVehicleDto createVehicleDto) {
      try {
        var vehicle = _vehiclesService.Create(createVehicleDto);
        return Ok(vehicle);
      }
      catch (Exception) {
        return InternalServerError();
      }
    }

    /// <summary>
    /// Delete a vehicle
    /// </summary>
    /// <param name="id">Id of the vehicle (as Guid format)</param>
    /// <returns></returns>
    [HttpDelete]
    public IHttpActionResult Delete(string id) {
      Guid guid = new Guid(id);
      try {
        _vehiclesService.Delete(guid);
        return Ok();
      }
      catch (Exception) {
        return InternalServerError();
      }
    }

    /// <summary>
    /// Modify (patch) a vehicle
    /// </summary>
    /// <param name="id">Id of the vehicle (guid)</param>
    /// <param name="modifyVehicleDto">Properties of the vehicle (insert in the body)</param>
    /// <returns>The modified vehicle</returns>
    [HttpPatch]
    public IHttpActionResult Modify([FromUri] string id, [FromBody] ModifyVehicleDto modifyVehicleDto) {
      Guid guid = new Guid(id);
      try {
        var vehicle = _vehiclesService.Modify(guid, modifyVehicleDto);
        return Ok(vehicle);
      }
      catch (Exception) {
        return InternalServerError();
      }
    }
  }
}
