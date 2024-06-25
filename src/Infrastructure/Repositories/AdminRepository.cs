using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AdminRepository : EfRepository<Admin>, IAdminRepository
    {
        //Traer  lista de movie y movie por id pero en el base

        public AdminRepository(ApplicationDbContext context) : base(context) 
        {
        }
      
        public Movie? GetByName(string name) 
        { 
             return _context.Movies.FirstOrDefault(p=> p.Title == name);
        
        }

        //ABM DE MOVIE QUE HICIMOS PARA VER EL CAMINO

        //public Movie AddMovie(Movie movie) 
        //{
        //    _context.Movies.Add(movie);
        //    return (movie);
        //}
        //public void DeleteMovie(Movie movie) 
        //{
        //    _context.Movies.Remove(movie);
        //}
        //public void UpdateMovie(Movie movie) 
        //{
        //    _context.Movies.Add(movie);
        //}
    }
}
