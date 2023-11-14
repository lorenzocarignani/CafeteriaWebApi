using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;

namespace CafeteriaWebApi.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly CafeteriaContext _context;

        public AdminService(CafeteriaContext context)
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
            User ?userDelete = _context.Users.FirstOrDefault(u => u.Id == userId);
            userDelete.State = false;
            _context.Update(userDelete);
            _context.SaveChanges();
        }

        public List<User> GetAdmins()
        {
            return _context.Users.Where(u => u.UserType == "Admin").ToList();
        }

        public List<User> GetClients()
        {
            return _context.Users.Where(c => c.UserType == "Client").ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
