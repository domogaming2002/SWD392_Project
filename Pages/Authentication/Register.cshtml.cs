using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Helper;
using SWD392_Project.Models;
using System.Net.Mail;
using System.Net;

namespace SWD392_Project.Pages.Authentication
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public RegisterModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string fullName, string email, string password, string phone)
        {
            User user = new User
            {
                Fullname = fullName,
                Email = email,
                Password = password,
                PhoneNumber = phone,
                RoleId = 2,
                IsDelete = false,
                IsActive = false
            };
            if (_userRepository.AddUser(user) <= 0)
            {
                TempData["messageResponse"] = "Register fail!";
            }
            else
            {
                // send email to active account
                if (_userRepository.SendEmail())
                {
                    TempData["messageResponse"] = "Register successfully! Check your email to activate account!";
                }
            }
            return Redirect("/register");
        }
    }
}
