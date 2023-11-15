using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Implementations;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
//PutActualizar
//PostPedido
//GetPedido
//DeleteCliente

namespace CafeteriaWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;

        public ClientController(IUserService userService, IOrderService orderService, IClientService clientService)
        {
            _userService = userService;
            _orderService = orderService;
            _clientService = clientService;
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



        [HttpGet]
        public string Get()
        {
            return "value";
        }

        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

