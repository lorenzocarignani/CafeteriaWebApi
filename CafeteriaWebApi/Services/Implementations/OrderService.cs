using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Order? GetOrder(int orderId)
        {
            return _context.Orders
                
                .SingleOrDefault(o => o.IdOrder == orderId);
        }

    }
}
