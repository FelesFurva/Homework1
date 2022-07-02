using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface IUserManager
    {
        void AddUserToDB(User newUser);
        User GetUser(string Email, string password);
        bool CheckIfEmailIsAvailable(string email);
    }
}
