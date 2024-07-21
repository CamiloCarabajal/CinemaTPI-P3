using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorMovie { get; set; }

        public static MovieDto ToDto(Movie movie)
        {
            var dto = new MovieDto()
            {
                Id = movie.Id,
                Title = movie.Title,
                AuthorMovie = movie.AuthorMovie,
            };
            return dto;
        }

        public static Movie ToEntity(MovieAddRequest movieDto) 
        {
            var movie = new Movie()
            {
                Id = movieDto.Id,
                Title = movieDto.Title,
                AuthorMovie = movieDto.AuthorMovie,
            };
            return movie;
        }

        public static Movie ToEntityUpdate(MovieUpdateRequest movieDto)
        {
            var movie = new Movie()
            {
                Title = movieDto.Title,
                AuthorMovie = movieDto.AuthorMovie,
            };
            return movie;
        }
        //Aca deberia ir lo mismo pero para un GetAll por ej
    }
}
