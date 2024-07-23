using Application.Interfaces;
using Application.Models.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutheticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAutenticationService _customAuthenticationService;

        public AutheticationController(IConfiguration config, ICustomAutenticationService autenticacionService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            _customAuthenticationService = autenticacionService;
        }
        [HttpPost]

        public ActionResult<string> Authenticate([FromBody] AuthenticationRequest credentials) 
        {
            string token = _customAuthenticationService.Authenticate(credentials); // Llamar a una función que valide los parámetros que enviamos.
            return Ok(token);
        }
    }
}
