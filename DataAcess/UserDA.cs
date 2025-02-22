using Entity;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserDA
    {
        private static UserDA user;
        private UserDA() { }
        public static UserDA GetUserAccess()
        {
            if (user == null)
            {
                user = new UserDA();
            }
            return user;
        }


        public int AddNewUser(User user)
        {
            const string query = "INSERT INTO Users VALUES (@PersonID, @UserName, @Password, @IsActive, @Role)";

            using (var conn = new SqlConnection(connectionString.Value))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonID", user.person.PersonID);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteUser(int id)
        {
            const string query = "DELETE FROM Users WHERE PersonID = @PersonID";

            using (var conn = new SqlConnection(connectionString.Value))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonID", id);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateUser(User user)
        {
            const string query = "UPDATE Users SET UserName = @UserName, Password = @Password, IsActive = @IsActive, Role = @Role WHERE UserID = @UserID";

            using (var conn = new SqlConnection(connectionString.Value))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", user.UserId);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllUsers()
        {
            const string query = "SELECT * FROM Users";

            using (var conn = new SqlConnection(connectionString.Value))
            using (var cmd = new SqlCommand(query, conn))
            {
                var dataTable = new DataTable();
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                return dataTable;
            }
        }

        public bool IsNationalNoExist(string nationalNo)
        {
            const string query = "SELECT COUNT(1) FROM Users INNER JOIN People ON Users.PersonID = People.PersonID WHERE People.NationalNo = @NationalNo";

            using (var conn = new SqlConnection(connectionString.Value))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NationalNo", nationalNo);

                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public User GetUserByID(int id)
        {
            const string query = @"
            SELECT * 
            FROM Users 
            INNER JOIN People ON Users.PersonID = People.PersonID 
            INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID 
            WHERE UserID = @id ";

            using (var conn = new SqlConnection(connectionString.Value))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            person = new People {
                                PersonID = (int)reader["personID"],
                                NationalNo = (string)reader["NationalNo"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gender = ((bool)reader["Gender"] == false ? 'M' : 'F'),
                                Address = (string)reader["Address"],
                                Phone = (string)reader["Phone"],
                                Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"],
                                Nationality = (string)reader["CountryName"],
                                ImagePath = reader["ImagePath"] == DBNull.Value ? null : (string)reader["ImagePath"]

                            },
                            UserName = (string)reader["UserName"],
                            Password = (string)reader["Password"],
                            UserId = (int)reader["UserID"],
                            Role = (int)reader["Role"],
                            IsActive = (bool)reader["IsActive"],
                        };
                    }
                }
            }

            return new User { UserId = -1 };
        }
        public User GetUserByUserNamePassword(string userName, string password)
        {
            const string query = @"
            SELECT *
            FROM Users 
            INNER JOIN People ON Users.PersonID = People.PersonID 
            INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID 
            WHERE UserName = @UserName AND Password = @Password";
            int userID = -1;
            using (var conn = new SqlConnection(connectionString.Value))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            person = new People
                            {
                                PersonID = (int)reader["personID"],
                                NationalNo = (string)reader["NationalNo"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gender = ((bool)reader["Gender"] == false ? 'M' : 'F'),
                                Address = (string)reader["Address"],
                                Phone = (string)reader["Phone"],
                                Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"],
                                Nationality = (string)reader["CountryName"],
                                ImagePath = reader["ImagePath"] == DBNull.Value ? null : (string)reader["ImagePath"]

                            },
                            UserName = (string)reader["UserName"],
                            Password = (string)reader["Password"],
                            UserId = (int)reader["UserID"],
                            Role = (int)reader["Role"],
                            IsActive = (bool)reader["IsActive"],
                        };
                    }

                }
            }
            return new User { UserId = -1 };
        }
    }
}
