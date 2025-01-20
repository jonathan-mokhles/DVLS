using Entity;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserAccess
    {
        private static UserAccess user;
        private UserAccess() { }
        public static UserAccess GetUserAccess() {
            if(user == null)
            {
                user = new UserAccess();
            }
            return user;
        }


        static string connectionString = "Server=JONATHAN_MOKHLE\\MSQLSERVER;Database=DVLD;User=sa;Password=123456";
        public int AddNewUser(User user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "insert into Users values (@PersonID,@userName,@password,@IsActive,@Role ";
            int ok = -1;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PersonID", user.ID);
                cmd.Parameters.AddWithValue("@userName", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                ok = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                conn.Close();
            }
            return ok;
        }
        public int DeleteUser(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "Delete from Users where [PersonID] = @PersonID";
            int ok = -1;


            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PersonID", id);

                ok = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                conn.Close();
            }
            return ok;

        }
        public int UpdateUser(User user)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "update Users set [Password] = @password, [IsActive] = @IsActive, [Role] = @Role " +
                "where [PersonID] = @PersonID";
            int ok = -1;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PersonID", user.ID);
                cmd.Parameters.AddWithValue("@userName", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                ok = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                conn.Close();
            }
            return ok;
        }
    
        public User GetUserByUserNamePassword(string userName, string password)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "select * from Users,People,Countries where UserName = @username and" +
                " Password = @password and people.PersonID = Users.PersonID and " +
                "People.NationalityCountryID = Countries.CountryID ";
            User user = new User();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", userName);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader =  cmd.ExecuteReader();

                if (reader.Read()) {
                    user.ID = (int)reader["personID"];
                    user.FirstName = (string)reader["FirstName"];
                    user.LastName = (string)reader["LastName"];
                    user.Address = (string)reader["Address"];
                    user.Nationality = (string)reader["CountryName"];
                    user.Email = (string)reader["Email"];
                    user.Phone = (string)reader["Phone"];
                    user.UserName = (string)reader["UserName"];
                    user.Password = (string)reader["Password"];
                    user.Role = (int)reader["Role"];
                    user.IsActive = (bool)reader["IsActive"];
                    user.DateOfBirth = (DateTime)reader["DateOfBirth"];
                }
                else
                {
                    
                }
                

            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                conn.Close();
            }
            return user;

        }
    }

}
