using AcercaTest.Models;
using AcercaTest.Services.DTOs.CredentialsValidation;
using AcercaTest.Services.Services;
using AcercaTest.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace AcercaTest.Controllers {
  [AllowAnonymous]
  [RoutePrefix("api/auth")]
  public class AuthController: ApiController {
    private ICredendialsValidationService _credentiasValidationService;

    public AuthController(ICredendialsValidationService credendialsValidationService) {
      _credentiasValidationService = credendialsValidationService;
    }

    [HttpPost]
    [Route("authenticate")]
    public IHttpActionResult Authenticate(AuthRequest login) {
      if (login == null)
        throw new HttpResponseException(HttpStatusCode.BadRequest);

      var credentials = Mapping.Mapping.Mapper.Map<CredentialsDto>(login);
      bool isCredentialValid = _credentiasValidationService.ValidateCredentials(credentials);
      if (isCredentialValid) {
        var token = TokenGenerator.GenerateTokenJwt(login.Username);
        return Ok(token);
      }
      else {
        return Unauthorized();
      }
    }
  }
}