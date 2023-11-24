using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeteriaWebApi.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize]
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
                string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();

                var res = _adminService.GetAdmins();
                if (role == "Admin") 
                {
                    
                    if (res == null)
                    {
                        return BadRequest(res);
                    }
                    return Ok(res);
                }
                return Forbid();

            } catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }


        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] AdminPostDto adminDto)
        {
            try
            {
                string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
                if (role == "Admin")
                {

                    var res = new Admin()
                    {
                        Email = adminDto.Email,
                        Name = adminDto.Name,
                        Password = adminDto.Password,
                    };
                    if (res == null)
                    {
                        return BadRequest(res);
                    }
                    int id = _userService.CreateUser(res);
                    return Ok(id);
                }
                return Forbid();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }

        }


        [HttpPut("UpdateAdmin/{AdminId}")]
        public IActionResult UpdateAdmin([FromRoute] int AdminId, [FromBody] UserPutDto userDto)
        {
            try
            {
                string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
                if (role == "Admin")
                {
                    var userToUpdate = new Admin()
                    {
                        Id = AdminId,
                        Email = userDto.Email,
                        Name = userDto.Name,
                        Password = userDto.Password,
                    };

                    int updatedUserId = _userService.UpdateUser(userToUpdate);

                    if (updatedUserId == 0)
                    {
                        return NotFound($"Usuario con ID {AdminId} no encontrado");
                    }

                    return Ok(updatedUserId);
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
                if (role == "Admin")
                {
                    if (userId == 0)
                    {
                        return NotFound();
                    }
                    _userService.DeleteUser(userId);
                    return NoContent();
                }
                return Forbid();

            }catch (Exception ex)
            {
                return StatusCode(500,"Error interno del servidor" +  ex.Message);
            }
        }

    }
}
