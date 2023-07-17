using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD392_Project.BussinessLayer.IRepository;
using SWD392_Project.Helper;
using SWD392_Project.Models;

namespace SWD392_Project.Pages.Authentication
{
    public class ChangePasswordModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string oldPassword, string newPassword)
        {
            int? userId = SessionHelper.GetIdFromSession(HttpContext.Session, "userId");
            if (userId.HasValue)
            {
                User user = _userRepository.GetUserById(userId.Value);
                if (user != null && user.Password.Equals(oldPassword))
                {
                    if (_userRepository.ChangePassword(userId.Value, newPassword) > 0)
                    {
                        TempData["messageResponse"] = "Change password successfully!";
                    } else
                    {
                        TempData["messageResponse"] = "Change password fail!";
                    }
                } else
                {
                    TempData["messageResponse"] = "Your old password is not correct!";
                }
            }
            return Redirect("/change-password");
        }
    }
}
