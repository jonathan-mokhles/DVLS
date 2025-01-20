using DataAccess;
using Entity;
using System;


namespace BusinessLayer
{
    public class UserBuisness
    {
        UserAccess userAccess = UserAccess.GetUserAccess();

        public User login(string username, string password)
        {
            return userAccess.GetUserByUserNamePassword(username, password);
        }
    }
}
