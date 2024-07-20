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
        [HttpPost]

        public IActionResult Authentication([FromBody] AuthenticationRequest authenticationRequest) 
        {
            return Ok("jwt");
        }
    }
}
