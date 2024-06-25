using Application.Interfaces;
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


        public Movie GetByName(string name) 
        {
            return _adminRepository.GetByName(name);
        }

        // ABM de MOVIE

        public Movie AddMovie(Movie movie) 
        {
            //Esto deberia recibir un dto y convertirlo a entidad para que lo entienda el repository
            return _adminRepository.AddMovie(movie);
        }
        public void DeleteMovie(Movie movie) 
        {
            _adminRepository.DeleteMovie(movie);
        }
        public void UpdateMovie(Movie movie) 
        {
            _adminRepository.UpdateMovie(movie);
        }

        
    }
}
