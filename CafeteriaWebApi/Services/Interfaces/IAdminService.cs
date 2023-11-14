using CafeteriaWebApi.Data.Entities;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface IAdminService
    {
        public List<Product> GetProducts();
        public List<User> GetClients();
        public List<User> GetAdmins();
        public int CreateUser(User user);   
        public void DeleteUser(int id);
    }
}
