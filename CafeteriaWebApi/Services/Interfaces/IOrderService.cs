using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface IOrderService
    {
        public int CreateOrder(Order order);
   
        public int UpdateOrder(Order order);

        public void DeleteOrder(int orderId);

        public Order? GetOrder(int Id, int orderId);

        public List<OrderResponseDto> GetAllOrders(int clientId);
    }
}
