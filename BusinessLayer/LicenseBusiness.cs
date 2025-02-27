using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{
    public class LicenseBusiness
    {
        public static int CreateLicense(DrivingLicense license)
        {
            return LicenseDA.InsertLicense(license);
        }
        public static void UpdateLicense(int LicenseID, bool IsActive)
        {
            LicenseDA.UpdateLicense(LicenseID,IsActive);
        }
        public static void DeleteLicense(int licenseID)
        {
            LicenseDA.DeleteLicense(licenseID);
        }
        public static DrivingLicense GetLicenseByID(int licenseID)
        {
            DrivingLicense license = LicenseDA.GetLicenseByID(licenseID);
            if (license != null)
            {
                license.Application = ApplicationBusiness.GetApplicationByID(license.Application.ID);
                license.Class = DrivinglicenseClassesBuisness.GetClass(license.Class.ID);
                license.CreatedByUser = UserBuisness.GetUser(license.CreatedByUser.UserId);
            }
            return license;
        }
        public static DataTable GetAllLicenses()
        {
            return LicenseDA.GetAllLicenses();
        }
        public static DrivingLicense GetLicenseByAppID(int appID)
        {
            LocalLicenseApplications localApp = LocalLicenseApplicationBusiness.GetLocalApplication(appID);

            DrivingLicense license =  LicenseDA.GetLicenseByAppID(localApp.ID);
            license.setApp(localApp);
            license.CreatedByUser = UserBuisness.GetUser(license.CreatedByUser.UserId);
            return license;
        }

        public static int[] RenewLicense(DrivingLicense license) {

            LicenseDA.UpdateLicense(license.LicenseID, false);


            int[] IDs = new int[2];
            LocalLicenseApplications localApp = new LocalLicenseApplications();

            localApp.person.PersonID = license.Application.person.PersonID;
            localApp.Date = license.IssueDate;
            localApp.Type.ID = 2;
            localApp.Status = ApplicationStatus.Completed;
            localApp.LastStatusDate = license.IssueDate;
            localApp.PaidFees = license.PaidFees;
            localApp.CreatedByUser.UserId = GlobalSettings.CurrentUser.UserId;
            localApp.Class.ID = license.Class.ID;

            IDs[0] = LocalLicenseApplicationBusiness.AddApp(localApp);


            license.Application.ID = IDs[0];

            IDs[1] = LicenseDA.InsertLicense(license);

            return IDs;
        }

    }
}
