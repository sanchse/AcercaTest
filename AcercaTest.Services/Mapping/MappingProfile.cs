using AcercaTest.Services.DTOs.Vehicles;
using AcercaTest.Services.Vehicles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.Mapping {
  public class MappingProfile : Profile {
    public MappingProfile() {
      //DTO to Entities
      CreateMap<ModifyVehicleDto, Vehicle>();
      CreateMap<CreateVehicleDto, Vehicle>();
    }
  }
}
