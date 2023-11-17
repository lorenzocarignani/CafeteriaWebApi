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

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order? GetOrder(int Id, int orderId)
        {
            //return _context.Orders
            //    .Include(c => c.Clients)
            //    .FirstOrDefault(o => o.IdOrder == orderId);
            return _context.Orders
                       .Include(o => o.Clients)
                       .FirstOrDefault(o => o.Clients.Id == Id && o.IdOrder == orderId);
        }

        public List<Order> GetAllOrders(int Id)
        {
            return _context.Orders
                       .Include(o => o.Clients)
                       .Where(o => o.Clients.Id == Id)
                       .ToList();
        }

        public int CreateOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
            return order.IdOrder;
        }
        
    }
}
