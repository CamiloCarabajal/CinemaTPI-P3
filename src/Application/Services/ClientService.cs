using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        //ABM TICKET

        public Ticket CreateTicket(Ticket ticket) 
        {
            return _clientRepository.CreateTicket(ticket);
        }
        public void UpdateTicket(Ticket ticket) 
        {
            _clientRepository.UpdateTicket(ticket);
        }
        public void DeleteTicket(Ticket ticket) 
        {
            _clientRepository.DeleteTicket(ticket);
        }


        //Movie

        public ICollection<Movie> GetMovies()
        {
            return _clientRepository.GetMovies();
        }

        //Traer movie por id
        //Traer Ticket por id(?
    }
}
