using System;
using System.Collections.Generic;
using DataAccess;
using Entity;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayer
{
    public class ApplicationBusiness
    {
        ApplicationDA application = new ApplicationDA();

        public DataTable GetAllApplication()
        {
           return application.GetAllApplications();
        }
        public int AddApplication(Applications app)
        {
            return application.AddApplication(app);
        } 
        public bool UpdateApplication(int ID, ApplicationStatus Status, DateTime LastStatusDate)
        {
            return application.UpdateApplication(ID,Status,LastStatusDate);
        } 
        public bool DeleteApplication(int app)
        {
            return application.DeleteApplication(app);
        }

        public Applications GetApplicationByID(int ID)
        {
            return application.GetApplication(ID);
        }



    }
}
