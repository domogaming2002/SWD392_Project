using Microsoft.EntityFrameworkCore;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.DataLayer.Manager;
using SWD392_Project.Helper;
using SWD392_Project.Models;
using System;

namespace SWD392_Project.BussinessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserManager manager;
        private readonly SWD_ProjectContext _context;
        public UserRepository(SWD_ProjectContext context)
        {
            _context = context;
        }
        public User GetUser(string email, string password)
        {
            manager = new UserManager(_context);
            User user = manager.GetUser(email, password);
            return user;
        }

        public User Login(string email, string password)
        {
            if (Validate(email, password))
            {   // check validate fields
                User user = GetUser(email, password);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public bool Validate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            return true;
        }
    }
}
