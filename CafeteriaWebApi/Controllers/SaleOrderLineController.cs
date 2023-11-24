using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeteriaWebApi.Controllers
{
    [Route("api/saleorderline")]
    [ApiController]
    [Authorize]
    public class SaleOrderLineController : ControllerBase
    {
        private readonly ISalesOrderLineService _saleOrderLineService;

        public SaleOrderLineController(ISalesOrderLineService saleOrderLineService)
        {
            _saleOrderLineService = saleOrderLineService;
        }

        [HttpGet("{saleOrderLineId}")]
        public async Task<IActionResult> GetSaleOrderLine(int saleOrderLineId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();

            if(role == "Admin") { 
            var saleOrderLine = await _saleOrderLineService.GetSaleOrderLineById(saleOrderLineId);

                if (saleOrderLine != null)
                {
                    var productName = saleOrderLine.Product?.NameProduct;
                    var orderTotalPrice = saleOrderLine.Order?.TotalPrice;
                    var quantityOfProduct = saleOrderLine.QuantityOfProduct;

                    var response = new
                    {
                        SaleOrderLineId = saleOrderLine.IdSaleOrderLine,
                        ProductName = productName,
                        QuantityOfProduct = quantityOfProduct,
                        OrderTotalPrice = orderTotalPrice * quantityOfProduct
                    };

                    return Ok(response);
                
                }
                else
                    {
                    return NotFound("SaleOrderLine not found");
                    }
            }
            return Forbid();
        }

        [HttpDelete("{saleOrderLineId}")]
        public async Task<IActionResult> DeleteSaleOrderLine(int saleOrderLineId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            var result = await _saleOrderLineService.DeleteSaleOrderLineById(saleOrderLineId);
            if (role == "Admin")
            {
                if (result)
                {
                return Ok("SaleOrderLine deleted successfully");
                }
                else
                {
                return NotFound("Failed to delete SaleOrderLine");
                }
            }
            return Forbid();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSaleOrderLine(int orderId, int productId, int quantity)
        {
            var result = await _saleOrderLineService.CreateSaleOrderLine(orderId, productId, quantity);
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                if (result)
                {
                    return Ok("SaleOrderLine created successfully");
                }
                else
                {
                    return BadRequest("Failed to create SaleOrderLine");
                }
            }
            return Forbid();
        }
    }
}