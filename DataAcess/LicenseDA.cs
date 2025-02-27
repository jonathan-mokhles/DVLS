using Entity;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class LicenseDA
    {
        public static int InsertLicense(DrivingLicense license)
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
                    command.Parameters.AddWithValue("@ApplicationID", license.Application.ID);
                    command.Parameters.AddWithValue("@PersonID", license.Application.person.PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", license.Class.ID);
                    command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", (object)license.Notes ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                    command.Parameters.AddWithValue("@IsActive", license.IsActive);
                    command.Parameters.AddWithValue("@IssueReason", (int)license.IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUser.UserId);

                    connection.Open();
                    int newID = Convert.ToInt32(command.ExecuteScalar());
                    return newID;
                }
            }
        }
        public static void UpdateLicense(int LicenseID,bool IsActive)
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
        public static void DeleteLicense(int licenseID)
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
        public static DrivingLicense GetLicenseByID(int licenseID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT *,
                                (select 1 from DetainedLicenses dl where dl.LicenseID = l.LicenseID and dl.IsReleased = 0) as IsDetain
                                FROM Licenses l WHERE LicenseID = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DrivingLicense license = new DrivingLicense();

                            license.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                            license.Application.ID = Convert.ToInt32(reader["ApplicationID"]);
                            license.Application.person.PersonID = Convert.ToInt32(reader["PersonID"]);
                            license.Class.ID = Convert.ToInt32(reader["LicenseClassID"]);
                            license.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            license.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            license.Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null;
                            license.PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            license.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            license.IssueReason = (IssueReason)Convert.ToInt32(reader["IssueReason"]);
                            license.CreatedByUser.UserId = Convert.ToInt32(reader["CreatedByUserID"]);
                            license.IsDetain = reader["IsDetain"] != DBNull.Value ? true : false;
                            return license;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static DrivingLicense GetLicenseByAppID(int AppID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT *,
                                (select 1 from DetainedLicenses dl where dl.LicenseID = l.LicenseID and dl.IsReleased = 0) as IsDetain
                                FROM Licenses l
                                WHERE ApplicationID = @AppID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppID", AppID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DrivingLicense license = new DrivingLicense();

                            license.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                            license.Application.ID = Convert.ToInt32(reader["ApplicationID"]);
                            license.Application.person.PersonID = Convert.ToInt32(reader["PersonID"]);
                            license.Class.ID = Convert.ToInt32(reader["LicenseClassID"]);
                            license.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            license.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            license.Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null;
                            license.PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            license.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            license.IssueReason = (IssueReason)Convert.ToInt32(reader["IssueReason"]);
                            license.CreatedByUser.UserId = Convert.ToInt32(reader["CreatedByUserID"]);
                            license.IsDetain = reader["IsDetain"] != DBNull.Value ? true : false;

                            return license;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static DataTable GetAllLicenses()
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
    }
}