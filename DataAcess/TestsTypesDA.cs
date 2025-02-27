using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess
{
    public class TestsTypesDA
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM TestTypes";

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static bool UpdateTestType(TestTypes test)
        {
            string query = "UPDATE TestTypes SET TestTypeTitle = @Title, TestTypeDescription = @Description, TestTypeFees = @Fees WHERE TestTypeID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", test.ID);
                    command.Parameters.AddWithValue("@Title", test.Title);
                    command.Parameters.AddWithValue("@Description", test.Description);
                    command.Parameters.AddWithValue("@Fees", test.Fees);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static TestTypes GetTestByID( int id)
        {
            string query = "SELECT * FROM TestTypes where TestTypeID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id",id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new TestTypes
                        {
                            ID = (int)reader["TestTypeID"],
                            Title = (string)reader["TestTypeTitle"],
                            Description = (string)reader["TestTypeDescription"],
                            Fees = (decimal)reader["TestTypeFees"]
                        };
                    }
                    return null;


                }
            }
        }
    }
}
