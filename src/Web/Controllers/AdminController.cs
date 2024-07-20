using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _admin;
        public AdminController(IAdminService admin)
        {
            _admin = admin;
        }

        //[HttpPost]
        //public ActionResult<MovieDto> AddMovie(MovieAddRequest movieDto) 
        //{
        //    //Aca iria la validacion primero de que es un admin. Una vez tiene acceso, la verificacion de que no sea null lo que trae
        //    return Ok(_admin.AddMovie(movieDto));
        //}

        //[HttpPut]
        //public IActionResult<MovieDto> UpdateMovie()

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_admin.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            return Ok(_admin.GetById(id));
        }

        [HttpGet("{name}")]
        public ActionResult GetByName([FromRoute] string name)
        {
            return Ok(_admin.GetByName(name));
        }

        [HttpPost]
        public ActionResult<AdminDto> AddAdmin([FromBody] AdminAddRequest newAdmin) 
        {
           var adminCreated = _admin.AddAdmin(newAdmin);
            return Ok(adminCreated);
        }
        [HttpPut]
        public ActionResult UpdateAdmin([FromRoute] int id, [FromBody] AdminUpdateRequest updateAdmin) 
        {
            return Ok(_admin.UpdateAdmin(id, updateAdmin));
        }

        [HttpDelete]
        public void Delete([FromRoute] int id)
        {
            _admin.DeleteAdmin(id);
        }
    }
}
