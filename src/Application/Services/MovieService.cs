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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAll() 
        {
            return _movieRepository.Get();
        }
        public Movie? GetById(int id) 
        {
           var findMovie=_movieRepository.Get(id);
            return findMovie;
        }

        public Movie GetByTitle(string title) 
        {
            return _movieRepository.GetByTitle(title);
        }

        public MovieDto AddMovie(MovieAddRequest request) 
        {
            var movieEntity= MovieDto.ToEntity(request);
            _movieRepository.Add(movieEntity);

            var movieDto= MovieDto.ToDto(movieEntity);
            return movieDto;
        }
        public MovieDto UpdateMovie(MovieUpdateRequest request, int id) 
        {
            var findMovie= _movieRepository.Get(id);
            if (findMovie != null) 
            {
                var movieEntity = MovieDto.ToEntityUpdate(request);
                _movieRepository.Update(movieEntity);
                var movieDto = MovieDto.ToDto(movieEntity);
                return movieDto;
            }
            else
            {
                throw new Exception("Movie no encontrada");
            }
        }
        public void DeleteMovie(int id) 
        {
            var findMovie = _movieRepository.Get(id);
            if (findMovie != null)
            {
                _movieRepository.Delete(findMovie);
            }
            else
            {
                throw new Exception("Movie no encontrada");
            }
        }
    }
}
