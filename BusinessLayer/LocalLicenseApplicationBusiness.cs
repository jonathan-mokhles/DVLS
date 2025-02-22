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
        LocalLicenseApplicationDA localApp = new LocalLicenseApplicationDA();
        public ApplicationBusiness AppBusiness = new ApplicationBusiness();
       public DataTable GetAll()
        {
            return localApp.GetAllLocalDrivingLicenseApplications();
        } 

        public int AddApp(LocalLicenseApplications app)
        {
             int id = AppBusiness.AddApplication(app.Application);
            localApp.AddLocalDrivingLicenseApplication(app.classID,id);
            return id;
        }
        public bool UpdateApp(LocalLicenseApplications app)
        {
            return AppBusiness.UpdateApplication(app.Application.ID,app.Application.Status, app.Application.LastStatusDate) && localApp.UpdateLocalDrivingLicenseApplication(app.LocalID,app.classID);
        }
        public bool DeleteApp(int ID)
        {
            int id = localApp.GetApp(ID).Application.ID;
            return localApp.DeleteLocalDrivingLicenseApplication(ID) && AppBusiness.DeleteApplication(id);

        }
        public bool IsPersonHaveApp(int personid, int classid)
        {
            return localApp.IsPersonHaveApplication(personid, classid);
        }
        public LocalLicenseApplications GetLocalApplication(int id)
        {
            return localApp.GetApp(id);
        }
    }
}
