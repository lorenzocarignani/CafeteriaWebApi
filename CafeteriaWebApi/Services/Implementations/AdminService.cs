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

        public List<User> GetAdmin()
        {
            return _context.Users.Where(u => u.UserType == "Admin").ToList();
        }


    }
}
