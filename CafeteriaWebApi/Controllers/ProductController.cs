using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Implementations;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProductos()
        {
            try
            {
                var res = _productService.GetAllProducts();
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
        [HttpGet("{idProducto}")]
        public IActionResult GetProduct([FromRoute] int idProducto)
        {
            try
            {
                var res = _productService.GetProductById(idProducto);
                if (res == null)
                {
                    return NotFound($"El producto con el id {idProducto} no se ha encontrado" );
                }
                return Ok(res);

            }catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProducts([FromBody] ProductDto productDto)
        {
            try
            {
                var res = new Product
                {
                    NameProduct = productDto.NameProduct,
                    Price = productDto.Price,
                };
                if (res == null)
                {
                    return BadRequest(res);
                }
                int id = _productService.CreateProduct(res);
                return Ok(id);

            }catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }

        [HttpPut("UpdateProduct/{idProduct}")]
        public IActionResult UpdateProduct([FromRoute] int idProduct, [FromBody] ProductDto product)
        {
            try
            {
                var productToUpdate = new Product()
                {
                    IdProduct = idProduct,
                    NameProduct = product.NameProduct,
                    Price = product.Price,
                };

                int updatedProductId = _productService.UpdateProduct(productToUpdate);

                if (updatedProductId == 0)
                {
                    return NotFound($"Producto con ID {idProduct} no encontrado");
                }

                return Ok($"Producto actualizado exitosamente, ID del producto: {updatedProductId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpDelete("DeleteProduct/{idProduct}")]
        public IActionResult DeleteProduct([FromRoute] int idProduct)
        {
            try
            {
                if (idProduct == null)
                {
                    return NotFound($"El producto con el ID: {idProduct} no fue encontrado");
                }
                _productService.DeleteProduct(idProduct);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }

    }
}
