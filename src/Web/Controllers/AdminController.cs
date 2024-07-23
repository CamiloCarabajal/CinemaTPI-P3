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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _admin;
        public AdminController(IAdminService admin)
        {
            _admin = admin;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim?.Value == "Admin")//Y super Admin
            {
            return Ok(_admin.GetAll());
            }
            return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
             if (roleClaim?.Value == "Admin")//Y super Admin
            {
            var admin = _admin.GetById(id);
            if (admin is not null)
            {
                return Ok(admin);
            }
            else 
            {
                return NotFound($"No se encontro el Admin con el id: {id}");
            }
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }

        [HttpGet("{name}")]
        public ActionResult GetByName([FromRoute] string name)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim?.Value == "Admin")//Y super Admin
            {
            var findAdmin = _admin.GetByName(name);
            if (findAdmin is not null)
            {
                return Ok(findAdmin);
            }
            else 
            {
                return NotFound($"No se encontro el admin con el nombre: {name}");
            }
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }

        [HttpPost]
        public ActionResult<AdminDto> AddAdmin([FromBody] AdminAddRequest newAdmin) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim.Value == "Admin" || roleClaim.Value == "SuperAdmin")//Y super Admin
            {
            var adminCreated = _admin.AddAdmin(newAdmin);
            return Ok(adminCreated);
            }
            return Forbid($"Usted no se encuentra autorizado para esta accion");
        }

        [HttpPut]
        public ActionResult UpdateAdmin([FromRoute] int id, [FromBody] AdminUpdateRequest updateAdmin) 
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim.Value == "Admin" || roleClaim.Value == "SuperAdmin")//Y super Admin
            {
            var findAdmin= _admin.GetById(id);
            if (findAdmin is not null)
            {
                return Ok(_admin.UpdateAdmin(id, updateAdmin));

            }
            else 
            {
                return NotFound($"No se encontro el Admin con el id: {id}");
            }
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }

        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
              if (roleClaim.Value == "Admin" || roleClaim.Value == "SuperAdmin")//Y super Admin
            {
            var findAdmin = _admin.GetById(id);
            if (findAdmin is not null)
            {
                _admin.DeleteAdmin(id);
            }
            else 
            {
                NotFound($"No se encontro el Admin con el id: {id}");
            }
            }
             return Forbid($"Usted no se encuentra autorizado para esta accion");
        }
    }
}
