using DataAccess.Context;
using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
     public class UserManager : IUserManager
    {
        private readonly IWebShop _webShopDB;

        public UserManager(IWebShop webShopDB)
        {
            _webShopDB = webShopDB;
        }

        public void AddUserToDB(User newUser)
        {
            if(newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            _webShopDB.User.Add(newUser);
            _webShopDB.SaveChanges();
        }

        public User GetUser(string Email, string password)
        {
            if(_webShopDB.User.FirstOrDefault(u => u.Email == Email) is User user
                && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }

        public bool CheckIfEmailIsTaken(string email)
        {
            return _webShopDB.User.FirstOrDefault(u => u.Email == email) != null;
        }
    }
}
