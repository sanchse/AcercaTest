using AcercaTest.Models;
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
    [HttpGet]
    [Route("echoping")]
    public IHttpActionResult EchoPing() {
      return Ok(true);
    }

    [HttpGet]
    [Route("echouser")]
    public IHttpActionResult EchoUser() {
      var identity = Thread.CurrentPrincipal.Identity;
      return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
    }

    [HttpPost]
    [Route("authenticate")]
    public IHttpActionResult Authenticate(AuthRequest login) {
      if (login == null)
        throw new HttpResponseException(HttpStatusCode.BadRequest);

      //TODO: Validate credentials Correctly, this code is only for this Test !!
      bool isCredentialValid = (login.Password == "123456");
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