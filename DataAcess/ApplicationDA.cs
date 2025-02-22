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
        public DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT * from Applications ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public int AddApplication(Applications application)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                INSERT INTO Applications
                VALUES (@ApplicationPersonID, GETDATE(), @ApplicationTypeID, @ApplicationStatus, GETDATE(), @PaidFees, @CreatedByUserID);
                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationPersonID", application.PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", application.TypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", application.Status);
                    command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserId);

                    connection.Open();
                    int newID = Convert.ToInt32(command.ExecuteScalar());
                    return newID;
                }
            }
        }
        public bool UpdateApplication(int ID, ApplicationStatus Status,DateTime LastStatusDate)
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
        public bool DeleteApplication(int applicationID)
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

        public Applications GetApplication(int ID) {


            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
SELECT
       a.ApplicationID, 
       a.ApplicantPersonID, 
       p.FirstName + p.LastName as FullName, 
       a.ApplicationDate, 
       a.ApplicationStatus, 
       a.LastStatusDate, 
       a.ApplicationTypeID,
	   at.ApplicationTypeTitle, 
       a.PaidFees, 
       a.CreatedByUserID,
	   u.UserName
FROM Applications a
JOIN People p ON a.ApplicantPersonID = p.personID
JOIN Users u ON a.CreatedByUserID = u.userID
JOIN ApplicationTypes at ON a.ApplicationTypeID = at.ApplicationTypeID

        WHERE a.ApplicationID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", ID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            return new Applications
                            {
                                ID = (int)reader["ApplicationID"],
                                PersonID = (int)reader["ApplicantPersonID"],
                                PersonName = (string)reader["FullName"],
                                Date = (DateTime)reader["ApplicationDate"],
                                Status = (ApplicationStatus)Convert.ToInt32(reader["ApplicationStatus"]),
                                LastStatusDate = (DateTime)reader["LastStatusDate"],
                                TypeID = (int)reader["ApplicationTypeID"],
                                TypeName = (string)reader["ApplicationTypeTitle"],
                                PaidFees = (decimal)reader["PaidFees"],
                                CreatedByUserId = (int)reader["CreatedByUserID"],
                                CreatedByUserName = (String)reader["UserName"],
                            };

                            };
                        }
                    }
                }
            return null;
        }

       
    }


}

