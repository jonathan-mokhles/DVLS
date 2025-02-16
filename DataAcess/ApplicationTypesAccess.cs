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
    public class ApplicationTypesAccess
    {
        static string connectionString = "Server=JONATHAN_MOKHLE\\MSQLSERVER;Database=DVLD;User=sa;Password=123456";

        public DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM ApplicationTypes";

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

        public bool UpdateApplicationType(DrivingApplicationType type)
        {
            string query = "UPDATE ApplicationTypes SET ApplicationTypeTitle = @Title, ApplicationFees = @Fees WHERE ApplicationTypeId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", type.ID);
                    command.Parameters.AddWithValue("@Title", type.Title);
                    command.Parameters.AddWithValue("@Fees", type.Fees);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }

}
