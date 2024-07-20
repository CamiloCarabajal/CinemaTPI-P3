using Application.Models.Requests;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        List<Client> GetAll();
        Client GetById(int id);
        Client? GetByName(string name);
        ClientDto AddClient(ClientAddRequest request);
        ClientDto UpdateClient(int id, ClientUpdateRequest client);
        void DeleteClient(int id);
    }
}
