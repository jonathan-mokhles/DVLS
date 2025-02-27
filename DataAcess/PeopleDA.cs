using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccess
{


   public class PeopleDA
    {


        public static DataTable GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(connectionString.Value);
             string query = "SELECT [PersonID],[NationalNo],[FirstName],[LastName],[DateOfBirth], " +
                "CASE WHEN [Gender] = 0 THEN 'Male' ELSE 'Female' END AS Gender, " +
                "[Address],[Phone],[CountryName] FROM [People],[Countries] " +
                "where Countries.CountryID = People.NationalityCountryID";

             SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
             DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            connection.Close();
             return dataTable;
            
        }

        public static People GetPersonByID(int id)
        {
                People person = new People();
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "select * from People where PersonID =@ID ;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
               SqlDataReader reader =  command.ExecuteReader();
                if (reader.Read())
                {
                    person.PersonID = (int)reader["personID"];
                    person.NationalNo = (string)reader["NationalNo"];
                    person.FirstName = (string)reader["FirstName"];
                    person.LastName = (string)reader["LastName"];
                    person.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    person.Gender = ((bool)reader["Gender"] == false ? 'M': 'F');
                    person.Address = (string)reader["Address"];
                    person.Phone = (string)reader["Phone"];
                    person.Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"];
                    person.NationalityID = (int)reader["NationalityCountryID"];
                    person.ImagePath = reader["ImagePath"] == DBNull.Value ? null : (string)reader["ImagePath"];

                }
                else
                {
                    person = null ;
                }
            }
            return person;


        }
        public static People GetPersonByNo(String nationalNo)
        {
                People person = new People();
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "select * from People where NationalNo =@No ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@No", nationalNo);

                connection.Open();
               SqlDataReader reader =  command.ExecuteReader();
                if (reader.Read())
                {
                    person.PersonID = (int)reader["personID"];
                    person.NationalNo = (string)reader["NationalNo"];
                    person.NationalNo = (string)reader["NationalNo"];
                    person.FirstName = (string)reader["FirstName"];
                    person.LastName = (string)reader["LastName"];
                    person.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    person.Gender = ((bool)reader["Gender"] == false ? 'M': 'F');
                    person.Address = (string)reader["Address"];
                    person.Phone = (string)reader["Phone"];
                    person.Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"];
                    person.NationalityID = (int)reader["NationalityCountryID"];
                    person.ImagePath = reader["ImagePath"] == DBNull.Value ? null : (string)reader["ImagePath"];

                }
                else
                {
                    person = null;
                }
            }
            return person;


        }
        public static int AddPerson(People person)
        {
            SqlConnection connection = new SqlConnection(connectionString.Value);
           
                string query = @"INSERT INTO People VALUES 
                               (@NationalNo,@FirstName, @LastName, @DateOfBirth, @Gender,@Address,@Phone,@Email, @Country, @ImagePath);
                                SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender == 'F');
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);
            command.Parameters.AddWithValue("@Country", person.NationalityID);

            if (person.Email == null)
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", person.Email);

            if (person.ImagePath == null)
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", person.ImagePath);

            connection.Open();
            int i =Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return i;


        }

        public static int UpdatePerson(People person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "UPDATE People SET NationalNo= @NationalNo, FirstName=@FirstName, LastName=@LastName, Address=@Address, ImagePath=@ImagePath, " +
                               "Gender=@Gender, DateOfBirth=@DateOfBirth, Phone=@Phone, NationalityCountryID=@Country,Email=@Email  WHERE PersonID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", person.PersonID);
                command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", person.Gender == 'F');
                command.Parameters.AddWithValue("@Address", person.Address);
                command.Parameters.AddWithValue("@Phone", person.Phone);
                if(person.Email == null)
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Email", person.Email);

                command.Parameters.AddWithValue("@Country", person.NationalityID);

                if(person.ImagePath == null)
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ImagePath", person.ImagePath);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static bool isUniqueNationalNo(string num)
        {
            SqlConnection connection = new SqlConnection(connectionString.Value);
            string query = "select NationalNo from People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", num);

            connection.Open();
            object value = command.ExecuteScalar();
            bool isUnique = false;
            if((string)value == null)
            {
                isUnique = true;
            }
            connection.Close();
            return isUnique;
        }
        public static int DeletePerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "DELETE FROM People WHERE PersonID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                return i;

            }
        }
    }


}


