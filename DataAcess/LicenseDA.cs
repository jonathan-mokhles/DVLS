using Entity;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class LicenseDA
    {
        public int InsertLicense(DrivingLicense license)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                INSERT INTO Licenses  
                VALUES (
                    @ApplicationID, 
                    @PersonID, 
                    @LicenseClassID, 
                    @IssueDate, 
                    @ExpirationDate, 
                    @Notes, 
                    @PaidFees, 
                    @IsActive, 
                    @IssueReason, 
                    @CreatedByUserID
                );
                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                    command.Parameters.AddWithValue("@PersonID", license.PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", license.LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", (object)license.Notes ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                    command.Parameters.AddWithValue("@IsActive", license.IsActive);
                    command.Parameters.AddWithValue("@IssueReason", (int)license.IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

                    connection.Open();
                    int newID = Convert.ToInt32(command.ExecuteScalar());
                    return newID;
                }
            }
        }

        public void UpdateLicense(int LicenseID,bool IsActive)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                UPDATE Licenses 
                SET 
                    IsActive = @IsActive
                WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLicense(int licenseID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public DrivingLicense GetLicenseByID(int licenseID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DrivingLicense
                            {
                                LicenseID = Convert.ToInt32(reader["LicenseID"]),
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                                PersonID = Convert.ToInt32(reader["PersonID"]),
                                LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]),
                                IssueDate = Convert.ToDateTime(reader["IssueDate"]),
                                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]),
                                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null,
                                PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                IssueReason = (IssueReason)Convert.ToInt32(reader["IssueReason"]),
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public DataTable GetAllLicenses()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "SELECT * FROM Licenses;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }

            return table;
        }

        public DataTable GetLicenseInfo(int? appID = null, int? licenseID = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT 
               l.LicenseID,
               l.ApplicationID,
			   l.PersonID,
			   l.LicenseClassID,
               l.IssueDate,
               l.ExpirationDate,
               IssueReason,
               l.Notes,
			   l.PaidFees,
			   l.CreatedByUserID,
               l.IsActive,
			   lc.ClassName,
			   p.FirstName +' '+ p.LastName as FullName, 
			   p.NationalNo,
			   (select 1 from DetainedLicenses dl where dl.LicenseID = l.LicenseID and dl.IsReleased = 0) as IsDetain,
               CASE WHEN p.Gender = 0 THEN 'Male'
                    WHEN p.Gender = 1 THEN 'Female' 
               END AS Gender,
               p.DateOfBirth,
               p.ImagePath
        FROM Licenses l
        JOIN Applications a ON l.ApplicationID = a.ApplicationID
        JOIN People p ON a.ApplicantPersonID = p.PersonID
        JOIN LocalDrivingLicenseApplications la ON la.ApplicationID = a.ApplicationID
        JOIN LicenseClasses lc ON lc.LicenseClassID = la.LicenseClassID
        WHERE (@AppID IS NOT NULL AND la.LocalDrivingLicenseApplicationID = @AppID)
           OR (@LicenseID IS NOT NULL AND l.LicenseID = @LicenseID);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@AppID", appID.HasValue ? (object)appID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@LicenseID", licenseID.HasValue ? (object)licenseID.Value : DBNull.Value);

                    DataTable table = new DataTable();
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                    return table;
                }
            }
        }
    }
}