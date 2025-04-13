using DataAccess;
using Entity;
using System;
using System.Data;


namespace BusinessLayer
{
    public class UserBuisness
    {
     
        public static DataTable GetAllUsers()
        {
            return UserDA.GetAllUsers();
        }
        public User login(string username, string password)
        {
           User user =  UserDA.GetUserByUserNamePassword(username, password);
            if (user != null)
            {
                user.person = PeopleBusiness.GetPerson(user.person.PersonID);
                user.Role = UserRolesDA.GetRoleById(user.Role.Id);
            }
            return user;
        }
        public static bool isUserExist(string No)
        {
            return UserDA.IsNationalNoExist(No);
        }
        public static int AddUser(User user)
        {
            return UserDA.AddNewUser(user);
        }
        public static int UpdateUser(User user)
        {
            return UserDA.UpdateUser(user);

        }
        public static int DeleteUser(int userid)
        {
            return UserDA.DeleteUser(userid);
        }
        public static User GetUser(int id) {
            User user = UserDA.GetUserByID(id);
            if (user != null)
            {
                user.person = PeopleBusiness.GetPerson(user.person.PersonID);
                user.Role = UserRolesDA.GetRoleById(user.Role.Id);
            }
            return user;
        }
    }
}
