using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebApi.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        public AdminController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [HttpGet("GetAdmin")]
        public IActionResult GetAdmins()
        {

            try
            {
                var res = _adminService.GetAdmins();
                if (res == null)
                {
                    return BadRequest(res);
                }
                return Ok(res);

            } catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var res = _adminService.GetProducts();
                if (res == null)
                {
                    return BadRequest(res);
                }
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }

        [HttpGet("GetClients")]
        public IActionResult GetClients()
        {

            try
            {
                var res = _adminService.GetClients();
                if (res == null)
                {
                    return BadRequest(res);
                }
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateAdmin([FromBody] AdminPostDto adminDto)
        {
            try
            {
                var res = new Admin()
                {
                    Email = adminDto.Email,
                    Name = adminDto.Name,
                    Password = adminDto.Password,
                    UserType = "Admin"
                };
                if (res == null)
                {
                    return BadRequest(res);
                }
                int id = _userService.CreateUser(res);
                return Ok(id);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }

        }

        [HttpPut("{userId}")]
        public IActionResult UpdateAdmin([FromRoute] int userId, [FromBody] UserPutDto userDto)
        {
            try
            {
                var userToUpdate = new Admin()
                {
                    Id = userId,
                    Email = userDto.Email,
                    Name = userDto.Name,
                    Password = userDto.Password,
                };

                int updatedUserId = _userService.UpdateAdmin(userToUpdate);

                if (updatedUserId == 0)
                {
                    return NotFound($"Usuario con ID {userId} no encontrado");
                }

                return Ok(updatedUserId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


    }
}
