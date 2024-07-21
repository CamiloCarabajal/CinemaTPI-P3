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
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        Movie GetByTitle(string title);
        MovieDto AddMovie(MovieAddRequest request);
        MovieDto UpdateMovie(MovieUpdateRequest request, int id);
        void DeleteMovie(int id);
    }
}
