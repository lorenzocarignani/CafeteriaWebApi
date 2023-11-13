namespace CafeteriaWebApi.Data.Entities
{
    public class Admin : User
    {
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
