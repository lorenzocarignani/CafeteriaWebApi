using CafeteriaWebApi.Data.Entities;

namespace CafeteriaWebApi.Services.Interfaces
{
    public interface IClientService
    {
        public List<User> GetClient();
    }
}
