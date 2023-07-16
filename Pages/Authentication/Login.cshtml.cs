using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Helper;

namespace SWD392_Project.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string email, string password)
        {
            var user = _userRepository.Login(email, password);
            if (user == null)
            {
                TempData["messageResponse"] = "Your email or password is incorrect!";
                return Redirect("/login");
            }
            else
            {
                // save userId and roleId to session
                SessionHelper.SetIdToSession(HttpContext.Session, "userId", user.Id);
                SessionHelper.SetIdToSession(HttpContext.Session, "roleId", user.RoleId);
                return Redirect("/dashboard");
            }
        }
    }
}
