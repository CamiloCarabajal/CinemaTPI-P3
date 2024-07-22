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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult<TicketDto> GetTicketByClientId( int clientId)
        {
            var ticketsClient = _ticketService.GetTicketByClientId(clientId);
            return Ok(ticketsClient);
        }
        [HttpGet ("GetAll")]
        public ActionResult<List<Ticket>> GetAll() 
        {
            return Ok(_ticketService.GetAll());
        }

        [HttpPost]
        public ActionResult<TicketDto> BuyEntrada([FromBody]TicketAddRequest request) 
        {
            var ticketNew= _ticketService.CreateTicket(request);
            return Ok(ticketNew);
        }

        //Delete
        [HttpDelete]
        public  void DeleteTicket(int idTicket) 
        {
            _ticketService.DeleteTicket(idTicket);
        }
    }
}
