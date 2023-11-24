using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpDelete("{saleOrderLineId}")]
        public async Task<IActionResult> DeleteSaleOrderLine(int saleOrderLineId)
        {
            var result = await _saleOrderLineService.DeleteSaleOrderLineById(saleOrderLineId);

            if (result)
            {
                return Ok("SaleOrderLine deleted successfully");
            }
            else
            {
                return NotFound("Failed to delete SaleOrderLine");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSaleOrderLine(int orderId, int productId, int quantity)
        {
            var result = await _saleOrderLineService.CreateSaleOrderLine(orderId, productId, quantity);

            if (result)
            {
                return Ok("SaleOrderLine created successfully");
            }
            else
            {
                return BadRequest("Failed to create SaleOrderLine");
            }
        }
    }
}