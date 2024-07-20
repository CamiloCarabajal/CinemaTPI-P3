using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        //MovieDto AddMovie(MovieAddRequest movieDto);
        List<Admin> GetAll();
        Admin? GetById(int id);
        Admin? GetByName(string name);
        AdminDto AddAdmin(AdminAddRequest request);
        AdminDto UpdateAdmin(int id, AdminUpdateRequest request);
        void DeleteAdmin(int id);
    }
}
