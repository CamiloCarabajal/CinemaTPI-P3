using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public  class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public List<TicketDto> GetTicketByClientId(int clientId) 
        {
           var ticketsClient= _ticketRepository.GetTicketByClientId(clientId);
            return ticketsClient.Select(t => new TicketDto
            {
                Id = t.Id,
                ClientName = t.ClientName,
                MovieId = t.MovieId,
                MovieTitle = t.Movie.Title
            }).ToList();
        }
        public List<Ticket> GetAll() 
        {
            return _ticketRepository.Get();
        }
        public TicketDto CreateTicket(TicketAddRequest request)
        {
            // Obtener el cliente y la película desde la base de datos
            var client = _ticketRepository.GetClient(request.ClientId);
            var movie = _ticketRepository.GetMovie(request.MovieId);

            if (client == null || movie == null)
            {
                throw new Exception("Cliente o película no encontrados.");
            }

            var ticket = new Ticket
            {
                ClientId = request.ClientId,
                MovieId = request.MovieId,
                ClientBuyer = client,
                Movie = movie,
                ClientName= client.Name,
            };

            _ticketRepository.Add(ticket);

            return new TicketDto
            {
                Id = ticket.Id,
                ClientName = ticket.ClientBuyer.Name,
                MovieId = ticket.MovieId,
                MovieTitle = ticket.Movie.Title
            };
        }

        public void DeleteTicket(int id) 
        {
            var ticketToDelete = _ticketRepository.Get(id);
            if (ticketToDelete != null)
            {
                _ticketRepository.Delete(ticketToDelete);
            }
            else 
            {
                throw new Exception("Ticket no encontrado");
            }
        }
    }
}
