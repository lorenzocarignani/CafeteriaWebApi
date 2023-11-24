using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeteriaWebApi.Services.Implementations
{
    public class SaleOrderLineService : ISalesOrderLineService
    {
        private readonly CafeteriaContext _context;

        public SaleOrderLineService(CafeteriaContext context)
        {
            _context = context;
        }

        public async Task<SaleOrderLine> GetSaleOrderLineById(int saleOrderLineId)
        {
            return await _context.SaleOrderLines
            .Include(sol => sol.Order)
            .Include(sol => sol.Product)
            .FirstOrDefaultAsync(sol => sol.IdSaleOrderLine == saleOrderLineId);
        }

        public async Task<bool> CreateSaleOrderLine(int orderId, int productId, int quantity)
        {
            try
            {
                var order = await _context.Orders.FindAsync(orderId);
                var product = await _context.Products.FindAsync(productId);

                if (order == null || product == null)
                {
                    return false; // Manejar el caso cuando no se encuentre la orden o el producto
                }

                var saleOrderLine = new SaleOrderLine
                {
                    OrderId = orderId,
                    ProductId = productId,
                    QuantityOfProduct = quantity
                };

                _context.SaleOrderLines.Add(saleOrderLine);
                await _context.SaveChangesAsync();

                return true; // Éxito al crear la línea de pedido
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return false;
            }
        }

        public async Task<bool> DeleteSaleOrderLineById(int saleOrderLineId)
        {
            try
            {
                var saleOrderLine = await _context.SaleOrderLines.FindAsync(saleOrderLineId);

                if (saleOrderLine == null)
                {
                    return false; // Manejar el caso cuando no se encuentra la SaleOrderLine
                }

                _context.SaleOrderLines.Remove(saleOrderLine);
                await _context.SaveChangesAsync();

                return true; // Éxito al eliminar la SaleOrderLine
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return false;
            }
        }

        // Puedes agregar más métodos según sea necesario para la lógica de negocio de SaleOrderLine
    }
}