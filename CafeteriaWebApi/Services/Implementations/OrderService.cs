using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
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

        public int UpdateOrder(Order order)
        {
            var existingOrder = _context.Orders.SingleOrDefault(o => o.IdOrder == order.IdOrder);

            if (existingOrder == null)
            {
                return 0;
            }

            existingOrder.NameOrder = order.NameOrder;
            existingOrder.Quantity = order.Quantity;

            _context.Update(existingOrder);
            _context.SaveChanges();

            return existingOrder.IdOrder;

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

        public List<OrderResponseDto> GetAllOrders(int clientId)
            
        {
            var clientOrders = _context.Orders
                                    .Where(o => o.Clients.Id == clientId)
                                    .Select(o => new OrderResponseDto
                                    {
                                        IdOrder = o.IdOrder,
                                        State = o.State,
                                        TotalPrice = o.TotalPrice,
                                        DeliveryTime = o.DeliveryTime,
                                        Quantity = o.Quantity,
                                        NameOrder = o.NameOrder,
                                        ClientId = o.ClientId,
                                  
                                    })
                                    .ToList();

            return clientOrders;
        }

        public int CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.IdOrder;
        }
        
    }
}
