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
        
        public User GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges();
        }
    }
}
