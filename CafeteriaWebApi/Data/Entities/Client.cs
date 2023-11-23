namespace CafeteriaWebApi.Data.Entities
{
    public class Client : User
    {
        public ICollection<Order>? Orders { get; set; }
        
    }
}
