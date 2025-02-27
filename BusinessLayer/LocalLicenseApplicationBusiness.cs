using System;
using System.Collections.Generic;
using DataAccess;
using Entity;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayer
{
    public class LocalLicenseApplicationBusiness
    {
       public static DataTable GetAll()
        {
            return LocalLicenseApplicationDA.GetAllLocalDrivingLicenseApplications();
        } 

        public  static int AddApp(LocalLicenseApplications app)
        {
             int id = ApplicationBusiness.AddApplication(app);
            LocalLicenseApplicationDA.AddLocalDrivingLicenseApplication(app.Class.ID,id);
            return id;
        }
        public static bool UpdateApp(LocalLicenseApplications app)
        {
            return ApplicationBusiness.UpdateApplication(app.ID,app.Status, app.LastStatusDate) && LocalLicenseApplicationDA.UpdateLocalDrivingLicenseApplication(app.LocalID,app.Class.ID);
        }
        public static bool DeleteApp(int ID)
        {
            int id = LocalLicenseApplicationDA.GetApp(ID).ID;
            return LocalLicenseApplicationDA.DeleteLocalDrivingLicenseApplication(ID) && ApplicationBusiness.DeleteApplication(id);

        }
        public static bool IsPersonHaveApp(int personid, int classid)
        {
            return LocalLicenseApplicationDA.IsPersonHaveApplication(personid, classid);
        }
        public static LocalLicenseApplications GetLocalApplication(int id)
        {
            LocalLicenseApplications app = LocalLicenseApplicationDA.GetApp(id);
            app.setApp(ApplicationBusiness.GetApplicationByID(app.ID));
            app.Class = DrivinglicenseClassesBuisness.GetClass(app.Class.ID);
            return app;

        }
    }
}
