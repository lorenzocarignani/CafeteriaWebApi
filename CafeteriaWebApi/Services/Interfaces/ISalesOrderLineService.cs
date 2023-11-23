using CafeteriaWebApi.Data.Entities;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface ISalesOrderLineService
    {
        public int CreateSaleOrderLine(SaleOrderLine sol);
        public int UpdateSaleOrderLine(SaleOrderLine sol);
        public void DeleteSaleOrderLine(int idSol);
        public SaleOrderLine GetSaleOrderLineById(int idSol);
    }
}
