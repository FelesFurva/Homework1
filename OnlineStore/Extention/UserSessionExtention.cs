using DataAccess.Context.Entity;

namespace OnlineStore.Extention
{
    public static class UserSessionExtention
    {
        public static void SetSession(this ISession session, User user)
        {
            session.SetInt32("id", user.UserId);
            session.SetString("name", user.Name);
            session.SetString("email", user.Email);
            session.SetString("userRole", user.Role.ToString());
        }

        public static string GetUsername(this ISession session) => session.GetString("name");

        public static int GetId(this ISession session) => session.GetInt32("id").Value;

        public static string GetUserRole(this ISession session) => session.GetString("userRole");

        public static bool IsUserAdmin(this ISession session)
        {
            return session.GetUserRole() == Role.Admin.ToString();
        }

        public static bool IsLoggedIn(this ISession session)
        {
            return session.GetInt32("id").HasValue;
        }

    }
}
