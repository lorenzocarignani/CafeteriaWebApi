using CafeteriaWebApi.Data.Entities;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface IUserService
    {
        public int CreateUser(User user);

        public int UpdateAdmin(User user); 

        public void DeleteUser(int userId);

        public User GetByEmail(string email);


    }
}
