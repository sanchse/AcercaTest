using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcercaTest.Services.DTOs.CredentialsValidation;

namespace AcercaTest.Services.Services {
  public class CredentialsValidationService : ICredendialsValidationService {
    public bool ValidateCredentials(CredentialsDto credentialsDto) {
      //TODO: Validate credentials HARDCODED. Maybe they should be allocated into a repo.
      return credentialsDto.Password == "123456";
    }
  }
}
