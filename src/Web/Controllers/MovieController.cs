using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim.Value == "Admin"|| roleClaim.Value == "Client")
            {
            return Ok(_movieService.GetAll());
            }
            return Forbid($"Usted no se encuentra autorizado para esta accion");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim.Value == "Admin"|| roleClaim.Value == "Client")
            {
            return Ok(_movieService.GetById(id));
            }
            return Forbid($"Usted no se encuentra autorizado para esta accion");
        }

        [HttpGet("{title}")]
        public IActionResult GetByTitle(string title)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim.Value == "Admin" || roleClaim.Value == "Client" )
            {

            var movie = _movieService.GetByTitle(title);
            if (movie is not null)
            {
                return Ok(movie);
            }
            else 
            {
                return NotFound($"No se encontro ninguna pelicula con el titulo de : {title}");
            }
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
        [HttpPost]
        public ActionResult<MovieDto> AddMovie([FromBody] MovieAddRequest request) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim.Value == "Admin")
             {
            var newAdmin = _movieService.AddMovie(request);
               return Ok($"Has agregado una nueva pelicula ");
             }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }

        [HttpPut]
        public ActionResult<MovieDto> UpdateMovie([FromBody] MovieUpdateRequest request, int id) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim.Value == "Admin")
            {
               var findMovie= _movieService.GetById(id);
            if (findMovie is not null)
            {
                //seguramente ya no necesite pasarle el id por que la verificacion esta aca en el controlador
                _movieService.UpdateMovie(request, id);
                return Ok($"Pelicula actualizada");
            }
            else
            {
                return NotFound($"No se encontro la pelicula");
            }
            }
            return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
        [HttpDelete]
        public ActionResult DeleteById(int id) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim.Value == "Admin")
            {
            var findmovie= _movieService.GetById(id);
            if (findmovie is not null)
            {
                _movieService.DeleteMovie(id);
                return Ok();
            }
            else 
              {
                return NotFound($"No se encontro la pelicula");
              }
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
    }
}
