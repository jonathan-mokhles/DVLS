using System;
using Entity;
using DataAccess;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer
{
    public class TestAppointmentBusiness
    {
        public static int CreateTestAppointment(TestAppointment appointment)
        {
            return TestAppointmentDA.InsertTestAppointment(appointment);
        }
        public static int CreateRetakeTestAppointment(TestAppointment appointment,decimal retakeFees)
        {
            Applications app = LocalLicenseApplicationBusiness.GetLocalApplication(appointment.LocalDrivingLicenseApplicationID);
            app.LastStatusDate = DateTime.Now;
            app.Date = DateTime.Now;
            app.Type.ID = 7;
            app.CreatedByUser.UserId = GlobalSettings.CurrentUser.UserId;
            app.PaidFees = retakeFees;

            int id = ApplicationBusiness.AddApplication(app);

            appointment.RetakeTestApplicationID = id;

            return TestAppointmentDA.InsertTestAppointment(appointment);
        }

        public static void UpdateTestAppointment(TestAppointment appointment)
        {
            TestAppointmentDA.UpdateTestAppointment(appointment);
        }
        public static void DeleteTestAppointment(int testAppointmentID)
        {
            TestAppointmentDA.DeleteTestAppointment(testAppointmentID);
        }
        public static TestAppointment GetTestAppointmentByID(int testAppointmentID)
        {
            return TestAppointmentDA.GetTestAppointmentByID(testAppointmentID);
        }
        public static DataTable GetTestAppointments(int typeId, int appId)
        {
            return TestAppointmentDA.GetAllTestAppointments( typeId,  appId);
        }
    }
}
