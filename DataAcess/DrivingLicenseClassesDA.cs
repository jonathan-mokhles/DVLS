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
    public class DrivingLicenseClassesDA
    {
        public DataTable GetAllClasses()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM LicenseClasses";

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

        public LicenseClass GetClassByID(int ID) {
            string query = "SELECT * FROM LicenseClasses where LicenseClassID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", ID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new LicenseClass
                        {
                            ID = (int)reader["LicenseClassID"],
                            DefaultValidityLength = (byte)reader["DefaultValidityLength"],
                            MinimumAllowedAge = (byte)reader["MinimumAllowedAge"],
                            Name = (string)reader["ClassName"],
                            Description = (string)reader["ClassDescription"],
                            Fees = (decimal)reader["ClassFees"]
                        };
                    }
                    return null;


                }
            }
        }
    }
    
}
