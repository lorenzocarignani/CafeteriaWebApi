using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Implementations;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CafeteriaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public ClientController(IUserService userService, IOrderService orderService, IClientService clientService, IProductService productService)
        {
            _userService = userService;
            _orderService = orderService;
            _clientService = clientService;
            _productService = productService;
        }

        [HttpGet("{id}/{orderId}")]
        public IActionResult GetOrderById(int id, int orderId)
        {
            try
            {
                var client = _clientService.GetClientById(id);
                if (client == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                // si la order coinicide con el id del cliente la trae si no no     
                var order = _orderService.GetOrder(id, orderId); 

                if (order == null)
                {
                    return NotFound("Orden no encontrada");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }



        [HttpGet("GetAllOrders/{id}")]
        public IActionResult GetOrders(int id)
        {
            try
            {
                var client = _clientService.GetClientById(id);
                if (client == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                // Obtiene todas las órdenes del cliente
                var orders = _orderService.GetAllOrders(id);

                // Mapea el cliente y las órdenes sin incluir la lista de órdenes directamente
                var clientResponse = new ClientResponseDto
                {
                    Id = client.Id,
                    Name = client.Name,
                    Password = client.Password,
                    Email = client.Email,
                    UserType = client.UserType,
                    UserState = client.UserState,
                    Orders = orders.Select(o => new OrderResponseDto
                    {
                        IdOrder = o.IdOrder,
                        State = o.State,
                        TotalPrice = o.TotalPrice,
                        DeliveryTime = o.DeliveryTime,
                        Quantity = o.Quantity,
                        NameOrder = o.NameOrder,
                        ClientId = o.ClientId
                        // No incluir la propiedad "Orders" 
                    }).ToList()
                };

                return Ok(clientResponse);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }


        [HttpPost("clients/{clientId}/orders")]
        public IActionResult CreateOrder([FromBody] OrderDto orderDto, int clientId)
        {

            try
            {
                var client = _clientService.GetClientById(clientId);
                if (client == null)
                {
                    return NotFound("Cliente no encontrado");
                }


                var order = new Order()
                {
                    NameOrder = orderDto.NameOrder,
                    Quantity = orderDto.Quantity,
                    Clients = (Client)client // si no lo ponia asi marcaba error , es para asociar la order al cliente
                };
                int id = _orderService.CreateOrder(order);
                return Ok($"el id de su producto es {id}");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }
        

        [HttpPut("{idOrder}")]
        public IActionResult UpdateOrder([FromBody]OrderDto orderDto, int idOrder )
        {
            try
            {
                var uOrder = new Order()
                {
                    IdOrder = idOrder,
                    NameOrder = orderDto.NameOrder,
                    Quantity = orderDto.Quantity
                };
                if (uOrder == null)
                {
                    return BadRequest(uOrder);
                }

                int id = _orderService.UpdateOrder(uOrder);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }

        }


        [HttpDelete("clients/{clientId}/orders/{orderId}")]
        public IActionResult DeleteOrder(int clientId, int orderId)
        {
            try
            {
                var client = _clientService.GetClientById(clientId);
                if (client == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                var order = _orderService.GetOrder(clientId, orderId);
                if (order == null)
                {
                    return NotFound("Orden no encontrada");
                }

                
                _orderService.DeleteOrder(orderId);

                return Ok("Orden eliminada exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }

    }
}

