using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaWebApi.Services.Implementations
{
    public class SalesOrderLineService : ISalesOrderLineService
     {
            private readonly CafeteriaContext _context;

            public SalesOrderLineService(CafeteriaContext context)
            {
                _context = context;
            }

            public int CreateSaleOrderLine(SaleOrderLine sol)
            {
                _context.Add(sol);
                _context.SaveChanges();
                return sol.IdSaleOrderLine;
            }

            public void DeleteSaleOrderLine(int idSol)
            {
                var saleOrderLine = _context.SaleOrderLines.FirstOrDefault(x => x.IdSaleOrderLine == idSol);

                if (saleOrderLine != null)
                {
                    _context.SaleOrderLines.Remove(saleOrderLine);
                    _context.SaveChanges();
                }
            }



            public SaleOrderLine GetSaleOrderLineById(int idSol)
            {
                return _context.SaleOrderLines
                               .Include(sol => sol.Products) // Cargar el producto relacionado
                               .Include(sol => sol.Orders)   // Cargar la orden relacionada
                               .FirstOrDefault(sol => sol.IdSaleOrderLine == idSol);
            }

            public int UpdateSaleOrderLine(SaleOrderLine sol)
            {
                var existingSol = _context.SaleOrderLines.SingleOrDefault(u => u.IdSaleOrderLine == sol.IdSaleOrderLine);

                if (existingSol == null)
                {
                    return 0;
                }

                existingSol.QuantityOfProduct = sol.QuantityOfProduct;
                existingSol.Discount = sol.Discount;

                _context.Update(existingSol);
                _context.SaveChanges();
                return existingSol.IdSaleOrderLine;
            }
    }
}
