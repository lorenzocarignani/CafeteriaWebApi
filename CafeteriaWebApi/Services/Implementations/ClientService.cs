﻿using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;

namespace CafeteriaWebApi.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly CafeteriaContext _context;

        public ClientService(CafeteriaContext context)
        {
            _context = context;

        }

        public User GetClientById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetClient()
        {
            return _context.Users.Where(u => u.UserType == "Client").ToList();
        }

     

      
    }
}
