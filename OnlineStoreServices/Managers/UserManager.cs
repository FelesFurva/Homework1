using DataAccess.Context;
using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public class UserManager : IUserManager
    {
        private readonly WebShopDBContext _webShopDB;

        public UserManager(WebShopDBContext webShopDB)
        {
            _webShopDB = webShopDB;
        }

        public void AddUserToDB(User newUser)
        {
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            _webShopDB.User.Add(newUser);
            _webShopDB.SaveChanges();

            var cart = new Cart
            {
                UserId = newUser.UserId,
            };

            _webShopDB.Cart.Add(cart);
            _webShopDB.SaveChanges();
        }

        public User GetUser(string Email, string password)
        {
            var user = _webShopDB.User.FirstOrDefault(u => u.Email == Email);
            bool verifiedPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (verifiedPassword)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public bool CheckIfEmailIsAvailable(string email)
        {
            return _webShopDB.User.FirstOrDefault(u => u.Email == email) != null;
        }
    }
}
