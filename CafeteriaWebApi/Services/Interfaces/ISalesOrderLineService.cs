using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Implementations;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface ISalesOrderLineService
    {
        Task<SaleOrderLine> GetSaleOrderLineById(int saleOrderLineId);
        Task<bool> DeleteSaleOrderLineById(int saleOrderLineId);
        Task<bool> CreateSaleOrderLine(int orderId, int productId, int quantity);

    }
}
