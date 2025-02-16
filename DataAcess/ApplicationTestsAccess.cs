using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess_DVLD_
{
    public class ApplicationTestsAccess
    {
        static string connectionString = "Server=JONATHAN_MOKHLE\\MSQLSERVER;Database=DVLD;User=sa;Password=123456";
        public DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM TestTypes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public bool UpdateTestType(DrivingApplicationTests test)
        {
            string query = "UPDATE TestTypes SET TestTypeTitle = @Title, TestTypeDescription = @Description, TestTypeFees = @Fees WHERE TestTypeID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
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
    }
}
