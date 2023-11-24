using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Implementations;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface ISalesOrderLineService
    {
        public List<SaleOrderLine> GetSaleOrderLineById (int IdSaleOrderLine);
        public int CreateSaleOrderLine(SaleOrderLine saleOrderLine);
        public void DeleteSaleOrderLine(int IdSaleOrderLine);
    }
}
