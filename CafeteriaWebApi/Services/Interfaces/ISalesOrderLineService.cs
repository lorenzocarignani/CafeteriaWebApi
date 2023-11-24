using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Implementations;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface ISalesOrderLineService
    {
        public List<SaleOrderLine> GetSaleOrderLines(int clientId, int orderId);
        public int CreateSaleOrderLine(SaleOrderLine saleOrderLine);
        public void DeleteSaleOrderLine(int saleOrderLineId);
    }
}
