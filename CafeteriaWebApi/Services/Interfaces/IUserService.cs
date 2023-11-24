using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface IUserService
    {
        public int CreateUser(User user);

        public int UpdateUser(User user); 

        public void DeleteUser(int userId);

        public User GetByEmail(string email);

        public BaseResponse ValidarUsuario(string username, string password);
    }
}
