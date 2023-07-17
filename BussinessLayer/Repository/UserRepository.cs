using Microsoft.EntityFrameworkCore;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.DataLayer.Manager;
using SWD392_Project.Helper;
using SWD392_Project.Models;
using System;
using System.Net.Mail;
using System.Net;

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
                if (user != null && user.IsActive == true)
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

        public User GetUserById(int userId)
        {
            manager = new UserManager(_context);
            User user = manager.GetUserById(userId);
            return user;
        }
        public bool SendEmail()
        {
            return true;
        }
        
        public int AddUser(User user)
        {
            manager = new UserManager(_context);
            return manager.AddUser(user);
        }


         public async void SendMailToActivate()
        {
            string email = "abc@gmail.com";
            var activationLink = $"https://example.com/activate?email={email}";
            var message = new MailMessage("swd392@hotmail.com", email, "Activate your account", activationLink);

            using (var smtpClient = new SmtpClient("smtp.live.com", 587))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("swd392@hotmail.com", "swd12345");
                smtpClient.EnableSsl = true;
                await smtpClient.SendMailAsync(message);
            }
        }


    }
}
