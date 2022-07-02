using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class UserExtention
    {
        public static UserCreateModel ToDBModel(this User user)
        {
            var userModel = new UserCreateModel
            {
                UserName = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            return userModel;
        }

        public static User ToEntity(this UserCreateModel user)
        {
            var userModel = new User
            {
                Name = user.UserName,
                Email = user.Email,
                Password = user.Password,
            };

            return userModel;
        }
    }
}
