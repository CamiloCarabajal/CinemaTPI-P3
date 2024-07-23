using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim.Value == "Admin" || roleClaim.Value == "SuperAdmin")
            {
            return Ok(_clientService.GetAll());
            }
            return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
        [HttpGet("{id}")]
        public ActionResult<Client> GetById([FromRoute]int id) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim.Value == "Admin" || roleClaim.Value == "SuperAdmin")
            {
            return Ok(_clientService.GetById(id));
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
        [HttpGet("{name}")]
        public ActionResult<Client?> GetByName([FromRoute] string name) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim.Value == "Admin" || roleClaim.Value == "SuperAdmin")
            {
            return _clientService.GetByName(name);
            }
             return Forbid();
        }
        [HttpPost]
        public ActionResult<ClientDto> AddClient(ClientAddRequest newClient) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim.Value == "Admin" || roleClaim.Value == "Client" || roleClaim.Value == "SuperAdmin")
            {
            return Ok(_clientService.AddClient(newClient));
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
        [HttpPut]
        public ActionResult<ClientDto> UpdateClient(int id, ClientUpdateRequest client) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim.Value == "Admin" || roleClaim.Value == "Client" || roleClaim.Value == "SuperAdmin")
            {
            return Ok(_clientService.UpdateClient(id, client));
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
        [HttpDelete]
        public IActionResult DeleteClient(int id) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim.Value == "Admin" || roleClaim.Value == "SuperAdmin")
            {
            var findClient = _clientService.GetById(id);
            if (findClient is not null)
            {
                _clientService.DeleteClient(id);
                return Ok();
            }
            else 
            {
                return NotFound($"No se encontro el Cliente con el id: {id}");
            }
            }
            return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
    }
}
