using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TestAppointmentDA
    {
        public static int InsertTestAppointment(TestAppointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                INSERT INTO TestAppointments 
                VALUES (
                    @TestTypeID, 
                    @LocalDrivingLicenseApplicationID, 
                    @AppointmentDate, 
                    @PaidFees, 
                    @CreatedByUserID, 
                    @RetakeTestApplicationID, 
                    @TestResult, 
                    @Notes
                );
                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", appointment.TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", appointment.LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", appointment.PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", appointment.CreatedByUserID);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", (object)appointment.RetakeTestApplicationID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TestResult",
                        appointment.TestResult == TestsResult.InProgress ? (object)DBNull.Value : (object)(int)appointment.TestResult);
                    command.Parameters.AddWithValue("@Notes", (object)appointment.Notes ?? DBNull.Value);

                    connection.Open();
                    int newID = Convert.ToInt32(command.ExecuteScalar());
                    return newID;
                }
            }
        }

        public static void UpdateTestAppointment(TestAppointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"
                UPDATE TestAppointments 
                SET 
                    AppointmentDate = @AppointmentDate, 
                    RetakeTestApplicationID = @RetakeTestApplicationID, 
                    TestResult = @TestResult, 
                    Notes = @Notes
                WHERE TestAppointmentID = @TestAppointmentID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", appointment.TestAppointmentID);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", (object)appointment.RetakeTestApplicationID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TestResult",
                                            appointment.TestResult == TestsResult.InProgress ? (object)DBNull.Value : (object)(int)appointment.TestResult);
                    command.Parameters.AddWithValue("@Notes", (object)appointment.Notes ?? DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTestAppointment(int testAppointmentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static TestAppointment GetTestAppointmentByID(int testAppointmentID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TestAppointment
                            {
                                TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]),
                                TestTypeID = Convert.ToInt32(reader["TestTypeID"]),
                                LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]),
                                AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                                PaidFees = Convert.ToDecimal(reader["PaidFees"]),
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]),
                                RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["RetakeTestApplicationID"]) : (int?)null,
                                TestResult = reader["TestResult"] != DBNull.Value ? (TestsResult)reader["TestResult"]: TestsResult.InProgress,
                                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null
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

        public static DataTable GetAllTestAppointments(int typeId, int appId)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                string query = @"SELECT 
                TestAppointmentID as AppointmentId,
                AppointmentDate,
                PaidFees,
                CASE 
                    WHEN TestResult IS NULL THEN 'InProgress'
                    WHEN TestResult = 0 THEN 'Failed'      
                    WHEN TestResult = 1 THEN 'Passed'      
                END as Status,
				Notes
                FROM TestAppointments where TestTypeID = @type and LocalDrivingLicenseApplicationID = @app
                order by AppointmentId desc ;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@type", typeId);
                    command.Parameters.AddWithValue("@app", appId);

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
