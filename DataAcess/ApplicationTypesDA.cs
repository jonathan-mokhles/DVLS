using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationTypesDA
    {

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            string query = "SELECT ApplicationTypeID as ID,ApplicationTypeTitle as TypeTitle, ApplicationFees as Fees" +
                "  FROM ApplicationTypes";

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

        public static bool UpdateApplicationType(ApplicationTypes type)
        {
            string query = "UPDATE ApplicationTypes SET ApplicationTypeTitle = @Title, ApplicationFees = @Fees WHERE ApplicationTypeId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
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

        public static ApplicationTypes GetTypeByID(int id) {
            string query = "SELECT * FROM ApplicationTypes where ApplicationTypeID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new ApplicationTypes
                        {
                            ID = (int)reader["ApplicationTypeID"],
                            Title = (string)reader["ApplicationTypeTitle"],
                            Fees = (decimal)reader["ApplicationFees"]
                        };
                    }
                    return null;


                }
            }
        }
    }

}
