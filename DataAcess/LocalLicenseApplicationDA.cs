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
        public DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
    SELECT 
    l.LocalDrivingLicenseApplicationID as ApplicationID, 
    lc.ClassName,
    p.NationalNo,
    p.FirstName + ' ' + p.LastName AS FullName,
    a.LastStatusDate,
    COUNT(CASE WHEN ta.TestResult = 1 THEN ta.TestAppointmentID END) AS PassedTests,
    CASE when a.ApplicationStatus = 1 then 'New' 
	when a.ApplicationStatus = 2 then 'Canceled'
	when a.ApplicationStatus = 3 then 'Completed'
	END  AS ApplicationStatus

FROM LocalDrivingLicenseApplications l
JOIN Applications a ON l.ApplicationID = a.ApplicationID
JOIN People p ON a.ApplicantPersonID = p.personID
JOIN LicenseClasses lc ON l.LicenseClassID = lc.LicenseClassID
LEFT JOIN TestAppointments ta ON ta.LocalDrivingLicenseApplicationID = l.LocalDrivingLicenseApplicationID

GROUP BY 
    l.LocalDrivingLicenseApplicationID, 
    lc.ClassName,
    p.NationalNo,
    p.FirstName, 
    p.LastName,
    a.LastStatusDate,
    a.ApplicationStatus;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public bool AddLocalDrivingLicenseApplication(int licenseClassID,int AppID)
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

        public bool UpdateLocalDrivingLicenseApplication(int localApplicationID, int licenseClassID)
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

        public bool DeleteLocalDrivingLicenseApplication(int localApplicationID)
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
        public bool IsPersonHaveApplication(int personID, int ClassID)
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

        public LocalLicenseApplications GetApp(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
SELECT l.LocalDrivingLicenseApplicationID, 
       l.LicenseClassID, 
	   lc.ClassName, 
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
FROM LocalDrivingLicenseApplications l
JOIN Applications a ON l.ApplicationID = a.ApplicationID
JOIN People p ON a.ApplicantPersonID = p.personID
JOIN Users u ON a.CreatedByUserID = u.userID
JOIN LicenseClasses lc ON l.LicenseClassID =lc.LicenseClassID

JOIN ApplicationTypes at ON a.ApplicationTypeID = at.ApplicationTypeID

        WHERE l.LocalDrivingLicenseApplicationID = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Ensures there is data
                        {
                            return new LocalLicenseApplications
                            {
                                Application = new Applications
                                {
                                    ID = (int)reader["ApplicationID"],
                                    PersonID = (int)reader["ApplicantPersonID"],
                                    PersonName = (string)reader["FullName"],
                                    Date = (DateTime)reader["ApplicationDate"],
                                    Status = (ApplicationStatus)Convert.ToInt32(reader["ApplicationStatus"]),
                                    LastStatusDate = (DateTime) reader["LastStatusDate"],
                                    TypeID = (int)reader["ApplicationTypeID"],
                                    TypeName = (string)reader["ApplicationTypeTitle"],
                                    PaidFees = (decimal)reader["PaidFees"],
                                    CreatedByUserId = (int)reader["CreatedByUserID"],
                                    CreatedByUserName = (String)reader["UserName"],
                                },
                                LocalID = (int)reader["LocalDrivingLicenseApplicationID"],
                                classID = (int)reader["LicenseClassID"],
                                className = (String)reader["ClassName"],
                            };
                        }
                    }
                }
            }
            return null; // Return null if no record is found
        }
    }
}
