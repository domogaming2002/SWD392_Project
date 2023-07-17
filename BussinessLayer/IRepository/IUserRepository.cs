using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.IRepository
{
    public interface IUserRepository
    {
        public User Login(string email, string password);
        public bool Validate(string email, string password);
        public User GetUser(string email, string password);
        public User GetUserById(int userId);
        public int AddUser(User user);
        public bool SendEmail();
        public int ChangePassword(int userId, string newPassword);
    }
}
