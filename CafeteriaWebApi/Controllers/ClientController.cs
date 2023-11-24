using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Implementations;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CafeteriaWebApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public ClientController(IUserService userService, IAdminService adminService, IOrderService orderService, IClientService clientService, IProductService productService)
        {
            _adminService = adminService;
            _userService = userService;
            _orderService = orderService;
            _clientService = clientService;
            _productService = productService;
        }

        [HttpGet("GetClients")]
        public IActionResult GetClients()
        {

            try
            {
                string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
                if (role == "Admin")
                {
                    var res = _adminService.GetClients();
                    if (res == null)
                    {
                        return BadRequest(res);
                    }
                    return Ok(res);
                }
                return Forbid();

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

        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                    if (userId == 0)
                {
                    return NotFound("Usuario no encontrado");
                }
                _userService.DeleteUser(userId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
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



    }
}

