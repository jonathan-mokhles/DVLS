using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entity;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LocalLicenseApplicationDA
    {
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "select * from LocalLicenseApplications_view order by ApplicationID desc";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static bool AddLocalDrivingLicenseApplication(int licenseClassID,int AppID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query =
                    @"
                INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                VALUES (@ApplicationID, @LicenseClassID);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", AppID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Returns true if the insertion was successful
                }
            }
        }

        public static bool UpdateLocalDrivingLicenseApplication(int localApplicationID, int licenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                UPDATE LocalDrivingLicenseApplications
                SET LicenseClassID = @LicenseClassID
                WHERE LocalDrivingLicenseApplicationID = @LocalApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalApplicationID", localApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Returns true if the update was successful
                }
            }
        }

        public static bool DeleteLocalDrivingLicenseApplication(int localApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalApplicationID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalApplicationID", localApplicationID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Returns true if the deletion was successful
                }
            }
        }
        public static bool IsPersonHaveApplication(int personID, int ClassID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT CASE WHEN EXISTS (
                            SELECT 1 FROM Applications a ,LocalDrivingLicenseApplications l
                            WHERE ApplicantPersonID = @personID 
                              AND a.ApplicationID = l.ApplicationID
                              AND LicenseClassID = @classID
                              AND ApplicationStatus != 2
                        ) THEN 1 ELSE 0 END";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@personID", personID);
                    command.Parameters.AddWithValue("@classID", ClassID);
                    connection.Open();
                    return (int)command.ExecuteScalar() == 1;
                }
            }
        }

        public static LocalLicenseApplications GetApp(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                                SELECT *
                                FROM LocalDrivingLicenseApplications l
                                WHERE l.LocalDrivingLicenseApplicationID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Ensures there is data
                        {
                            LocalLicenseApplications app = new LocalLicenseApplications();
                            app.LocalID = (int)reader["LocalDrivingLicenseApplicationID"];
                            app.ID = (int)reader["ApplicationID"];
                            app.Class.ID = (int)reader["LicenseClassID"];

                            return app;
                            

                        }
                    }
                }
            }
            return null; // Return null if no record is found
        }
    }
}
