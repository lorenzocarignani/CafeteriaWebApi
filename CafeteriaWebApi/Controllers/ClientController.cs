using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Implementations;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
//PutActualizar
//PostPedido
//DeleteCliente

namespace CafeteriaWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
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
  
                // si la order coinicide con el id del cliente la trae si no no

                var orders = _orderService.GetAllOrders(id);
                if (orders == null || orders.Count == 0)
                {
                    return NotFound("Ordenes no encontrada");
                }
                return Ok(orders);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }

        
        //[HttpPost("CreateOrder")]
        //public IActionResult CreateOrder([FromBody] OrderDto orderDto)
        //{
            
        //    try
        //    {
        //        List<Product> product = _productService.GetAllProducts();

        //        var order = new Order
        //        {
        //            NameOrder = product,
        //            Quantity = orderDto.Quantity 
        //        };


        //        if (order == null)
        //        {
        //            return NotFound("Ordenes no encontrada");
        //        }

        //        int id = _orderService.CreateOrder(order);
        //        return Ok(id);

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error interno del servidor" + ex.Message);
        //    }
        //}

        
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

