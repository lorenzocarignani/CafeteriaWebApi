using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CafeteriaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderLineController : ControllerBase
    {
        private readonly ISalesOrderLineService _saleOrderLineService;

        public SaleOrderLineController(ISalesOrderLineService saleOrderLineService)
        {
            _saleOrderLineService = saleOrderLineService;
        }

        [HttpGet("clients/{clientId}/orders/{orderId}/saleOrderLines")]
        public IActionResult GetSaleOrderLines(int clientId, int orderId)
        {
            try
            {
                var saleOrderLines = _saleOrderLineService.GetSaleOrderLines(clientId, orderId);
                return Ok(saleOrderLines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPost("clients/{clientId}/orders/{orderId}/saleOrderLines")]
        public IActionResult CreateSaleOrderLine(int clientId, int orderId, [FromBody] SaleOrderLineDto saleOrderLineDto)
        {
            try
            {
                var saleOrderLine = new SaleOrderLine
                {
                    QuantityOfProduct = saleOrderLineDto.QuantityOfProduct,
                    ProductId = saleOrderLineDto.ProductId,
                    OrderId = orderId
                };

                int id = _saleOrderLineService.CreateSaleOrderLine(saleOrderLine);
                return Ok($"El id de su SaleOrderLine es {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("saleOrderLines/{saleOrderLineId}")]
        public IActionResult DeleteSaleOrderLine(int saleOrderLineId)
        {
            try
            {
                _saleOrderLineService.DeleteSaleOrderLine(saleOrderLineId);
                return Ok("SaleOrderLine eliminada exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        // Puedes agregar más acciones según sea necesario para la lógica de negocio de SaleOrderLine
    }
}