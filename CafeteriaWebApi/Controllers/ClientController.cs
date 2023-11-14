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

        public ClientController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        //[HttpGet("{id}")]
        //public IActionResult GetOrder()
        //{

        //}

        [HttpGet("{email}/orders/{orderId}")]
        public IActionResult GetOrderById(string email, int orderId)
        {
            // Obtén el usuario por su dirección de correo electrónico
            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            // Luego, obtén la orden por su ID
            var order = _orderService.GetOrder(orderId);

            // Verifica si la orden existe
            if (order == null)
            {
                return NotFound("Orden no encontrada");
            }

            return Ok(order);
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

