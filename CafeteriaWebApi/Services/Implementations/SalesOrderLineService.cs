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

        public List<SaleOrderLine> GetSaleOrderLines(int clientId, int orderId)
        {
            return _context.SaleOrderLines
                .Include(s => s.Product)
                .Where(s => s.OrderId == orderId && s.Order.Clients.Id == clientId)
                .ToList();
        }

        public int CreateSaleOrderLine(SaleOrderLine saleOrderLine)
        {
            _context.SaleOrderLines.Add(saleOrderLine);
            _context.SaveChanges();
            return saleOrderLine.IdSaleOrderLine;
        }

        public void DeleteSaleOrderLine(int saleOrderLineId)
        {
            var saleOrderLineToDelete = _context.SaleOrderLines.Find(saleOrderLineId);

            if (saleOrderLineToDelete != null)
            {
                _context.SaleOrderLines.Remove(saleOrderLineToDelete);
                _context.SaveChanges();
            }
        }

        // Puedes agregar más métodos según sea necesario para la lógica de negocio de SaleOrderLine
    }
}