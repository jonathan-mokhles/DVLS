using System;
using Entity;
using DataAccess;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer
{
    public class TestAppointmentBusiness
    {
        TestAppointmentDA _testAppointmentDA = new TestAppointmentDA();
        ApplicationBusiness _applicationBusiness = new ApplicationBusiness();
        LocalLicenseApplicationBusiness _localBusiness = new LocalLicenseApplicationBusiness();
        public int CreateTestAppointment(TestAppointment appointment)
        {
            return _testAppointmentDA.InsertTestAppointment(appointment);
        }
        public int CreateRetakeTestAppointment(TestAppointment appointment,decimal retakeFees)
        {
            Applications app =  _localBusiness.GetLocalApplication(appointment.LocalDrivingLicenseApplicationID).Application;
            app.LastStatusDate = DateTime.Now;
            app.Date = DateTime.Now;
            app.TypeID = 7;
            app.CreatedByUserId = GlobalSettings.CurrentUserID;
            app.PaidFees = retakeFees;

            int id = _applicationBusiness.AddApplication(app);

            appointment.RetakeTestApplicationID = id;

            return _testAppointmentDA.InsertTestAppointment(appointment);
        }

        public void UpdateTestAppointment(TestAppointment appointment)
        {
            _testAppointmentDA.UpdateTestAppointment(appointment);
        }
        public void DeleteTestAppointment(int testAppointmentID)
        {
            _testAppointmentDA.DeleteTestAppointment(testAppointmentID);
        }
        public TestAppointment GetTestAppointmentByID(int testAppointmentID)
        {
            return _testAppointmentDA.GetTestAppointmentByID(testAppointmentID);
        }
        public DataTable GetTestAppointments(int typeId, int appId)
        {
            return _testAppointmentDA.GetAllTestAppointments( typeId,  appId);
        }
    }
}
