using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(_clientService.GetAll());
        }
        [HttpGet]
        public ActionResult<Client> GetById([FromRoute]int id) 
        {
            return Ok(_clientService.GetById(id));
        }
        [HttpGet]
        public ActionResult<Client?> GetByName([FromRoute] string name) 
        {
            return _clientService.GetByName(name);
        }
        [HttpPost]
        public ActionResult<ClientDto> AddClient(ClientAddRequest newClient) 
        {
            return Ok(_clientService.AddClient(newClient));
        }
        [HttpPut]
        public ActionResult<ClientDto> UpdateClient(int id, ClientUpdateRequest client) 
        {
            return Ok(_clientService.UpdateClient(id, client));
        }
        [HttpDelete]
        public IActionResult DeleteClient(int id) 
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
    }
}
