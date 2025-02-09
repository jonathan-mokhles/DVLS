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
    public class PeopleAccess
    {
        private static PeopleAccess peopleAccess;
        private PeopleAccess() { }
        public static PeopleAccess getPeopleAccess()
        {
            if(peopleAccess == null)
            {
                peopleAccess = new PeopleAccess();
            }
            return peopleAccess;

        }

        static string connectionString = "Server=JONATHAN_MOKHLE\\MSQLSERVER;Database=DVLD;User=sa;Password=123456";

        public DataTable GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(connectionString);
             string query = "SELECT [PersonID],[NationalNo],[FirstName],[LastName],[DateOfBirth], " +
                "CASE WHEN [Gender] = 0 THEN 'M' ELSE 'F' END AS Gender, " +
                "[Address],[Phone],[Email] ,[CountryName] FROM [People],[Countries] " +
                "where Countries.CountryID = People.NationalityCountryID";

             SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
             DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            connection.Close();
             return dataTable;
            
        }

        public People GetPersonByID(int id)
        {
                People person = new People();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select * from People,Countries where PersonID =@ID and " +
                "People.NationalityCountryID = Countries.CountryID ";
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
                    person.Nationality = (string)reader["CountryName"];
                    person.ImagePath = reader["ImagePath"] == DBNull.Value ? null : (string)reader["ImagePath"];

                }
                else
                {
                    person.PersonID = -1;
                }
            }
            return person;


        }
        public People GetPersonByNo(String nationalNo)
        {
                People person = new People();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select * from People,Countries where NationalNo =@No and " +
                "People.NationalityCountryID = Countries.CountryID ";
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
                    person.Nationality = (string)reader["CountryName"];
                    person.ImagePath = reader["ImagePath"] == DBNull.Value ? null : (string)reader["ImagePath"];

                }
                else
                {
                    person.PersonID = -1;
                }
            }
            return person;


        }
        public int AddPerson(People person)
        {
            SqlConnection connection = new SqlConnection(connectionString);
           
                string query = "INSERT INTO People VALUES " +
                               "(@NationalNo,@FirstName, @LastName, @DateOfBirth, @Gender,@Address,@Phone,@Email, @Country, @ImagePath)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender == 'F');
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);
            command.Parameters.AddWithValue("@Country", GetCountryID(person.Nationality));

            if (person.Email == null)
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", person.Email);

            if (person.ImagePath == null)
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", person.ImagePath);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;


        }
        private int GetCountryID(string country)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select CountryID from Countries WHERE CountryName = @name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", country);

            connection.Open();
           object value = command.ExecuteScalar();
            int id =  Convert.ToInt32(value);
            connection.Close();
            return id;

        }

        public int UpdatePerson(People person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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

                command.Parameters.AddWithValue("@Country", GetCountryID(person.Nationality));

                if(person.ImagePath == null)
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ImagePath", person.ImagePath);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public bool isUniqueNationalNo(string num)
        {
            SqlConnection connection = new SqlConnection(connectionString);
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
        public int DeletePerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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


