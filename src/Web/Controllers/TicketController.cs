using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMovieService _movieService;

        public TicketController(ITicketService ticketService, IMovieService movieService)
        {
            _ticketService = ticketService;
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<TicketDto> GetTicketByClientId(int clientId)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim.Value == "Client")
            {
                var ticketsClient = _ticketService.GetTicketByClientId(clientId);
                return Ok(ticketsClient);
            }
            else if (roleClaim.Value is not "client")
            {
                return Forbid($"Usted no se encuentra autorizado para esta accion");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAll")]
        public ActionResult<List<Ticket>> GetAll()
        {
            return Ok(_ticketService.GetAll());
        }

        [HttpPost]
        public ActionResult<TicketDto> BuyEntrada([FromBody] TicketAddRequest request)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim.Value == "Client")
            {
                var movie = _movieService.GetById(request.MovieId);
                if (movie == null)
                {
                    return NotFound("Pelicula no encontrada");
                }
                else if (movie.SeatCount <= 0)
                {
                    return BadRequest("No hay asientos disponibles para esta pelicula");
                }
                else
                {
                    var ticketNew = _ticketService.CreateTicket(request);
                    return Ok(ticketNew);
                }
            }
            else
            {
                return Forbid($"Usted no se encuentra autorizado para esta accion");
            }
        }

        //Delete
        [HttpDelete]
        public IActionResult DeleteTicket(int idTicket)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim.Value == "Client" || roleClaim.Value == "Admin")
            {
                _ticketService.DeleteTicket(idTicket);
                return Ok($"Se ha eliminado con exito su ticket");
            }
            else
            {
                return Forbid($"Usted no se encuentra autorizado para esta accion");
            }
        }

        [HttpGet("/available-seats")]
        public IActionResult GetAvailableSeats(int id) 
        {
            var movieSeats= _movieService.GetById(id);
            if (movieSeats == null)
            {
                return BadRequest($"No se encontro la pelicula");
            }
            else if (movieSeats.SeatCount <= 0)
            {
                return BadRequest($"Pelicula sin asientos disponibles");
            }
            else
            {
                return Ok($"Asientos disponibles: {movieSeats.SeatCount}");
            }
        }

    }
}
