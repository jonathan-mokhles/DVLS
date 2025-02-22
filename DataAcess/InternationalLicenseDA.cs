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
        public int CreateLicense(InternationalLicense license)
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
                    command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                    command.Parameters.AddWithValue("@PersonID", license.PersonID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", license.IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", license.IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public void UpdateLicense(int InternationalLicenseID,bool IsActive)
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

        public void DeleteLicense(int licenseId)
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

        public bool GetLicenseByPersonId(int PersonId)
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
        public DataTable GetLicenseById(int licenseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT 
               l.InternationalLicenseID,
               l.ApplicationID,
			   l.IssuedUsingLocalLicenseID,
               l.IssueDate,
               l.ExpirationDate,
               l.IsActive,
			   p.FirstName +' '+ p.LastName as FullName, 
			   p.NationalNo,
               CASE WHEN p.Gender = 0 THEN 'Male'
                    WHEN p.Gender = 1 THEN 'Female' 
               END AS Gender,
               p.DateOfBirth,
               p.ImagePath
        FROM InternationalLicenses l
        JOIN Applications a ON l.ApplicationID = a.ApplicationID
        JOIN People p ON a.ApplicantPersonID = p.PersonID
        WHERE l.InternationalLicenseID  = @LicenseID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", licenseId);

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
        public DataTable GetAllLicenses()
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




    



