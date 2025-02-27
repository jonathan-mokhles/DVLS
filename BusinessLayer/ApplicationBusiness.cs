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

        public static DataTable GetAllApplication()
        {
           return ApplicationDA.GetAllApplications();
        }
        public static int AddApplication(Applications app)
        {
            return ApplicationDA.AddApplication(app);
        } 
        public static bool UpdateApplication(int ID, ApplicationStatus Status, DateTime LastStatusDate)
        {
            return ApplicationDA.UpdateApplication(ID,Status,LastStatusDate);
        } 
        public static bool DeleteApplication(int app)
        {
            return ApplicationDA.DeleteApplication(app);
        }

        public static Applications GetApplicationByID(int ID)
        {
             Applications app =  ApplicationDA.GetApplication(ID);
            app.person = PeopleBusiness.GetPerson(app.person.PersonID);
            app.Type = ApplicationTypesBuisness.GetType(app.Type.ID);
            app.CreatedByUser = UserBuisness.GetUser(app.CreatedByUser.UserId);
            return app;
        }



    }
}
