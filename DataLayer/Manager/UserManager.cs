using SWD392_Project.Models;

namespace SWD392_Project.DataLayer.Manager
{
    public class UserManager
    {
        private readonly SWD_ProjectContext _context;
        public UserManager(SWD_ProjectContext context)
        { _context = context; }
        public User GetUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
