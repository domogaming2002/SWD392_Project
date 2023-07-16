using SWD392_Project.Models;

namespace SWD392_Project.BussinessLayer.IRepository
{
    public interface IUserRepository
    {
        public User Login(string email, string password);
        public bool Validate(string email, string password);
        public User GetUser(string email, string password);
    }
}
