using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public static Client ToEntity(ClientAddRequest clientDto)
        {
            var entity = new Client()
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                Password = clientDto.Password,
            };
            return entity;
        }
        public static Client ToEntityUpdate(ClientUpdateRequest clientDto)
        {
            var entity = new Client()
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                Password = clientDto.Password,
            };
            return entity;
        }

        public static ClientDto ToDto(Client client) 
        {
            var dto = new ClientDto() 
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
            };
            return dto;
        }
    }

}
