using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DetainedLicensesDA
    {
        public int CreateDetainedLicense(int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString.Value))
            {
                string query = @"INSERT INTO DetainedLicenses
                                (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                                VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                                SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", licenseID);
                cmd.Parameters.AddWithValue("@DetainDate", detainDate);
                cmd.Parameters.AddWithValue("@FineFees", fineFees);
                cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public DataTable GetAllDetainedLicenses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString.Value))
            {
                string query = "SELECT * FROM DetainedLicenses";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void UpdateDetainedLicense(int detainID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString.Value))
            {
                string query = "UPDATE DetainedLicenses SET IsReleased = @IsReleased, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID WHERE DetainID = @DetainID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IsReleased", isReleased);
                cmd.Parameters.AddWithValue("@ReleaseDate", (object)releaseDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReleasedByUserID", (object)releasedByUserID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", (object)releaseApplicationID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DetainID", detainID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataRow GetDetainedInfoByLicenseID(int LicenseID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString.Value))
            {
                string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }
    }
}
