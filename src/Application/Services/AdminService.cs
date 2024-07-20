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
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }


        //public Movie GetByName(string name) 
        //{
        //    return _adminRepository.GetByName(name);
        //}

        // ABM de MOVIE
        // Esto solo lo puede hacer admin
        //public MovieDto AddMovie(MovieAddRequest movieDto)
        //{
        //    //var entityMovie = MovieDto.ToEntity(movieDto);
        //    // _adminRepository.Add(entityMovie);// Preguntar si al ser admin, solo puede vrear admin con datos genericos. De ser asi seguramente hay que hacer un Movie Repository(?
        //    //Esto no funciona por que deberia tener movie su propio controller. De ser admin dejamos que agregue la peli, de no ser no!!!
        //    // _adminRepository.SaveChangesAsync(); Falto por el cancellation token
        //    var entityMovie = new Movie()
        //    {
        //        Id = movieDto.Id,
        //        Title = movieDto.Title,
        //        AuthorMovie = movieDto.AuthorMovie,  //La solucion momentanea estuvo en instanciar el objeto aca directamente
        //    };
        //    return MovieDto.ToDto(entityMovie);
        //}
        //public void DeleteMovie(Movie movie) 
        //{
        //    _adminRepository.DeleteMovie(movie);
        //}
        //public void UpdateMovie(Movie movie) 
        //{
        //    _adminRepository.UpdateMovie(movie);
        //}


        public List<Admin> GetAll()
        {
            return _adminRepository.Get();
        }
        public Admin? GetById(int id)
        {
            return _adminRepository.Get(id);
        }
        public Admin? GetByName(string name)
        {
            return _adminRepository.GetByName(name);
        }

        public AdminDto AddAdmin(AdminAddRequest request)
        {
            var adminEntity = AdminDto.ToEntity(request);
            _adminRepository.Add(adminEntity);
            //Creo que no es necesario devolver el obj
            var adminDto = AdminDto.ToDto(adminEntity);
            return adminDto;
        }

        public AdminDto UpdateAdmin(int id, AdminUpdateRequest request)
        {
            var findAdmin = _adminRepository.Get(id);
            if (findAdmin != null)
            {
                var adminEntity = AdminDto.ToEntityUpdate(request);
                _adminRepository.Update(adminEntity);
                var adminDto = AdminDto.ToDto(adminEntity);
                return adminDto;
            }
            else
            {
                throw new Exception("Admin no encontrado");
            }
        }

        public void DeleteAdmin(int id) 
        {
            var findAdmin= _adminRepository.Get(id);
            if (findAdmin != null)
            {
                _adminRepository.Delete(findAdmin);
            }
            else 
            {
                throw new Exception("Admin no encontrado");
            }
        }

    }
}
