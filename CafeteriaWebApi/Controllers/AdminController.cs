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

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] AdminPostDto adminDto)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }

        }


        [HttpPost("CreateClient")]
        public IActionResult CreateClient([FromBody] AdminPostDto adminDto)
        {
            try
            {
                var res = new Client()
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
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut("UpdateClient/{ClientId}")]
        public IActionResult UpdateClient([FromRoute] int ClientId, [FromBody] UserPutDto userDto)
        {
            try
            {
                var clientToUpdate = new Client()
                {
                    Id = ClientId,
                    Email = userDto.Email,
                    Name = userDto.Name,
                    Password = userDto.Password,
                };

                int updatedClientId = _userService.UpdateUser(clientToUpdate);

                if (updatedClientId == 0)
                {
                    return NotFound($"Usuario con ID {ClientId} no encontrado");
                }

                return Ok(updatedClientId);
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
                if (userId == 0)
                {
                    return NotFound();
                }
                _userService.DeleteUser(userId);
                return NoContent();

            }catch (Exception ex)
            {
                return StatusCode(500,"Error interno del servidor" +  ex.Message);
            }
        }

    }
}
