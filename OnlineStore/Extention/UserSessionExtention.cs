﻿using DataAccess.Context.Entity;

namespace OnlineStore.Extention
{
    public static class UserSessionExtention
    {
        public static void SetSession(this ISession session, User user)
        {
            session.SetInt32("id", user.UserId);
            session.SetString("name", user.Name);
            session.SetString("email", user.Email);
        }

        public static string GetUsername(this ISession session) => session.GetString("name");

        public static int GetId(this ISession session) => session.GetInt32("id").Value;
    }
}
