using AcercaTest.Models;
using AcercaTest.Services.DTOs.CredentialsValidation;
using AutoMapper;

namespace AcercaTest.Mapping {
  public class MappingProfile : Profile {
    public MappingProfile() {
      CreateMap<AuthRequest, CredentialsDto>();
    }
  }
}