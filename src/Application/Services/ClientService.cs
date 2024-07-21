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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        ////ABM TICKET

        //public Ticket CreateTicket(Ticket ticket) 
        //{
        //    return _clientRepository.CreateTicket(ticket);
        //}
        //public void UpdateTicket(Ticket ticket) 
        //{
        //    _clientRepository.UpdateTicket(ticket);
        //}
        //public void DeleteTicket(Ticket ticket) 
        //{
        //    _clientRepository.DeleteTicket(ticket);
        //}


        ////Movie

        //public ICollection<Movie> GetMovies()
        //{
        //    return _clientRepository.GetMovies();
        //}

        //Traer movie por id
        //Traer Ticket por id(?


        public List<Client> GetAll()
        {
            return _clientRepository.Get();
        }
        public Client GetById(int id) 
        {
            return _clientRepository.Get(id);
        }

        public Client? GetByName(string name) 
        {
            return _clientRepository.GetByName(name);
        }

        public ClientDto AddClient(ClientAddRequest request) 
        {
            var clientEntity = ClientDto.ToEntity(request);
            _clientRepository.Add(clientEntity);
            //Quizas no es necesario
            var clientDto = ClientDto.ToDto(clientEntity);
            return clientDto;
        }

        public ClientDto UpdateClient(int id, ClientUpdateRequest client) 
        {
            var findClient= _clientRepository.Get(id);
            if (findClient != null)
            {
                var clientEntity = ClientDto.ToEntityUpdate(client);
                _clientRepository.Add(clientEntity);
                //Quizas no es necesario
                var clientDto = ClientDto.ToDto(clientEntity);
                return clientDto;
            }
            else 
            {
                throw new Exception("Cliente no encontrado");
            }
        }

        public void DeleteClient(int id) 
        {
            var findClient = _clientRepository.Get(id);
            if (findClient != null)
            {
                _clientRepository.Delete(findClient);
            }
            else 
            {
                throw new Exception("Cliente no encontrado");
            }
        }
    }
}
