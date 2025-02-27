using System;
using System.Collections.Generic;
using Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess
{
    public class ApplicationDA
    {
        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT * from Applications order by ApplicationID desc";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public static int AddApplication(Applications application)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                INSERT INTO Applications
                VALUES (@ApplicationPersonID, GETDATE(), @ApplicationTypeID, @ApplicationStatus, GETDATE(), @PaidFees, @CreatedByUserID);
                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationPersonID", application.person.PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", application.Type.ID);
                    command.Parameters.AddWithValue("@ApplicationStatus", application.Status);
                    command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUser.UserId);

                    connection.Open();
                    int newID = Convert.ToInt32(command.ExecuteScalar());
                    return newID;
                }
            }
        }
        public static bool UpdateApplication(int ID, ApplicationStatus Status,DateTime LastStatusDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                UPDATE Applications
                SET ApplicationStatus = @ApplicationStatus,
                    LastStatusDate = @LastStatusDate
                WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ID);
                    command.Parameters.AddWithValue("@ApplicationStatus", (byte)Status);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
        }
        public static bool DeleteApplication(int applicationID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
        }

        public static Applications GetApplication(int ID) {


            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT * FROM Applications a WHERE a.ApplicationID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            Applications Application = new Applications();

                            Application.ID = (int)reader["ApplicationID"];
                            Application.person.PersonID = (int)reader["ApplicantPersonID"];
                            Application.Date = (DateTime)reader["ApplicationDate"];
                            Application.Status = (ApplicationStatus)Convert.ToInt32(reader["ApplicationStatus"]);
                            Application.LastStatusDate = (DateTime)reader["LastStatusDate"];
                            Application.Type.ID = (int)reader["ApplicationTypeID"];
                            Application.PaidFees = (decimal)reader["PaidFees"];
                            Application.CreatedByUser.UserId = (int)reader["CreatedByUserID"];

                            return Application;
                            

                            };
                        }
                    }
                }
            return null;
        }

       
    }


}

