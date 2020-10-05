using AcercaTest.Models;
using AutoMapper;

namespace AcercaTest.Mapping {
  public class MappingProfile : Profile {
    public MappingProfile() {
      CreateMap<Services.Vehicles.Vehicle, Vehicle>();
    }
  }
}