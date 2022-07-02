using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class UserSessionExtention
    {
        public static void SetSession(this HttpContext context, User user)
        {
            context.Session.SetInt32("id", user.UserId);
            context.Session.SetString("name", user.Name);
            context.Session.SetString("email", user.Email);
        }
    }
}
