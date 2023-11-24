using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Data.Models;
using CafeteriaWebApi.Services.Interfaces;

namespace CafeteriaWebApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly CafeteriaContext _context;
        public UserService(CafeteriaContext context) 
        {
            _context = context;
        }

        public int CreateUser(User user)
        {
            _context.Add(user); 
            _context.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(int userId)
        {
            User userToDelete = _context.Users.SingleOrDefault(u => u.Id == userId);
            userToDelete.UserState = Enums.StateUser.Disabled;
            _context.Update(userToDelete);
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public int UpdateUser(User user)
        {

            var existingUser = _context.Users.SingleOrDefault(u => u.Id == user.Id);

            if (existingUser == null)
            {
                return 0 ;
            }

            existingUser.Email = user.Email;
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;

            _context.Update(existingUser);
            _context.SaveChanges();

            return existingUser.Id;
        }

        public BaseResponse ValidarUsuario(string email, string password)
        {
            BaseResponse response = new BaseResponse();
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "loging Succesfull";
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }

    }
}
