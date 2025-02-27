using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InternationalLicenseDA
    {
        public static int CreateLicense(InternationalLicense license)
        {
            using (var connection = new SqlConnection(connectionString.Value))
            {
                 connection.Open();

                const string sql = @"
                INSERT INTO InternationalLicenses 
                VALUES 
                (@ApplicationID, @PersonID, @IssuedUsingLocalLicenseID, @IssueDate, 
                 @ExpirationDate, @IsActive, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", license.Application.ID);
                    command.Parameters.AddWithValue("@PersonID", license.Application.person.PersonID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", license.IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", license.IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUser.UserId);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public static void UpdateLicense(int InternationalLicenseID,bool IsActive)
        {
            using (var connection = new SqlConnection(connectionString.Value))
            {
                 connection.Open();

                const string sql = @"
                UPDATE InternationalLicenses 
                SET
                    IsActive = @IsActive,
                WHERE InternationalLicenseID = @InternationalLicenseID";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@InternationalLicenseID",InternationalLicenseID);
                     command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteLicense(int licenseId)
        {
            using (var connection = new SqlConnection(connectionString.Value))
            {
                 connection.Open();

                const string sql = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @LicenseId";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@LicenseId", licenseId);
                     command.ExecuteNonQuery();
                }
            }
        }

        public static bool IsPersonHasLicense(int PersonId)
        {
            using (var connection = new SqlConnection(connectionString.Value))
            {
                 connection.Open();

                using (var command = new SqlCommand("SELECT 1  FROM InternationalLicenses WHERE PersonID = @PersonId", connection))
                {
                    command.Parameters.AddWithValue("@PersonId", PersonId);

                    return Convert.ToInt32(command.ExecuteScalar()) == 1;
                    
                }
            }
        }
        public static InternationalLicense GetLicenseById(int licenseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT *
                     FROM InternationalLicenses l
                     WHERE l.InternationalLicenseID  = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", licenseId);

                    connection.Open();
                        InternationalLicense license = new InternationalLicense();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            license.InternationalLicenseID = (int)reader["InternationalLicenseID"];
                            license.Application.ID = (int)reader["ApplicationID"];
                            license.Application.person.PersonID = (int)reader["PersonID"];
                            license.IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                            license.IssueDate = (DateTime)reader["IssueDate"];
                            license.ExpirationDate = (DateTime)reader["ExpirationDate"];
                            license.IsActive = (bool)reader["IsActive"];
                            license.CreatedByUser.UserId = (int)reader["CreatedByUserID"];
                        }
                    }
                    return license;
                }
            }
        }
        public static DataTable GetAllLicenses()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT 
               l.InternationalLicenseID as ID,
               l.ApplicationID,
			   l.IssuedUsingLocalLicenseID AS LocalLicenseID ,
               l.IssueDate,
               l.ExpirationDate,
               l.IsActive
                FROM InternationalLicenses l";

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




    



