using DataAccess;
using Entity;
using System;
using System.Data;


namespace BusinessLayer
{
    public class UserBuisness
    {
        UserAccess userAccess = UserAccess.GetUserAccess();

       
        public DataTable GetAllUsers()
        {
            return userAccess.GetAllUsers();
        }
        public User login(string username, string password)
        {
            return userAccess.GetUserByUserNamePassword(username, password);
        }
        public bool isUserExist(string No)
        {
            return userAccess.IsNationalNoExist(No);
        }
        public int AddUser(User user)
        {
            return userAccess.AddNewUser(user);
        }
        public int UpdateUser(User user)
        {
            return userAccess.UpdateUser(user);

        }
        public int DeleteUser(int userid)
        {
            return userAccess.DeleteUser(userid);
        }
        public User GetUser(int id) {
            return userAccess.GetUserByID(id);
        }
    }
}
