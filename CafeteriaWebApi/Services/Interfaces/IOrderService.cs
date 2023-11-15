using CafeteriaWebApi.Data.Entities;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface IOrderService
    {
        public int CreateOrder(Order order);

        public void UpdateOrder(Order order);

        public void DeleteOrder(int orderId);

        public Order? GetOrder(int Id, int orderId);
    }
}
