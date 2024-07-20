using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public static AdminDto ToDto(Admin admin) { 

         var dto = new AdminDto()
        {
            Id = admin.Id,
            Name = admin.Name,
            Email = admin.Email,
        };
            return dto;
        }

    public static Admin ToEntity(AdminAddRequest adminDto)
    {
        var admin = new Admin()
        {
           Name = adminDto.Name,
           Email = adminDto.Email,
            Password=adminDto.Password
        };
       return admin;
     }
        public static Admin ToEntityUpdate(AdminUpdateRequest adminDto)
        {
            var admin = new Admin()
            {
                Name = adminDto.Name,
                Email = adminDto.Email,
                Password = adminDto.Password
            };
            return admin;
        }
    }
}
