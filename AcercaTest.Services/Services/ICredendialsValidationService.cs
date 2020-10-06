using AcercaTest.Services.DTOs.CredentialsValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcercaTest.Services.Services {
  public interface ICredendialsValidationService {
    bool ValidateCredentials(CredentialsDto credentialsDto);
  }
}
