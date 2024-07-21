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
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Movie GetByTitle(string title) 
        {
            var findMovie= _context.Movies.FirstOrDefault(x => x.Title == title);
            if (findMovie == null)
            {
                throw new Exception("No se encontro la pelicula");
            }
            else
            {
                return findMovie;
            }
        }

    }
}
