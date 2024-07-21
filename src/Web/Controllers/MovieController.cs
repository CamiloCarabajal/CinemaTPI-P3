using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
            return Ok(_movieService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_movieService.GetById(id));
        }
        [HttpGet("{title}")]
        public IActionResult GetByTitle(string title)
        {
            return Ok(_movieService.GetByTitle(title));
        }
        [HttpPost]
        public ActionResult<MovieDto> AddMovie([FromBody] MovieAddRequest request) 
        {
            return Ok(_movieService.AddMovie(request));
        }

        [HttpPut]
        public ActionResult<MovieDto> UpdateMovie([FromBody] MovieUpdateRequest request, int id) 
        {
            return Ok(_movieService.UpdateMovie(request, id));
        }
        [HttpDelete]
        public ActionResult DeleteById(int id) 
        {
            _movieService.DeleteMovie(id);
            return Ok();
        }
    }
}
