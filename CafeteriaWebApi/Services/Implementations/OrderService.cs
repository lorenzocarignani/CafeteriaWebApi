using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;

namespace CafeteriaWebApi.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly CafeteriaContext _context;

        public OrderService(CafeteriaContext context)
        {
            _context = context;
        }

        public int CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
