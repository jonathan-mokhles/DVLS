using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using DataAccess;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayer
{
    public class InternationalLicenseBusiness
    {

        public static int[] CreateLincense(InternationalLicense license,decimal fees)
        {
            int[] IDs = new int[2];
            Applications app = new Applications();
            app.person.PersonID = license.Application.person.PersonID;
            app.Date = license.IssueDate;
            app.Type.ID = 6;
            app.Status = ApplicationStatus.Completed;
            app.LastStatusDate = license.IssueDate;
            app.CreatedByUser.UserId = GlobalSettings.CurrentUser.UserId;
            app.PaidFees = fees;


            IDs[0] = ApplicationBusiness.AddApplication(app);
            license.Application.ID = IDs[0];
            IDs[1] = InternationalLicenseDA.CreateLicense(license);

            return IDs;

        }
        public void UpdateLicense(int LicenseID, bool IsActive)
        {
            InternationalLicenseDA.UpdateLicense(LicenseID,IsActive);
        }
        public static void DeleteLicense(int licenseId)
        {
            InternationalLicenseDA.DeleteLicense(licenseId);
        }
        public static InternationalLicense GetLicenseByID(int licenseId)
        {
           InternationalLicense license =  InternationalLicenseDA.GetLicenseById(licenseId);
            license.Application = ApplicationBusiness.GetApplicationByID(license.Application.ID);
            license.CreatedByUser = UserBuisness.GetUser(license.CreatedByUser.UserId);
            return license;

        }        
        public static DataTable GetLAllLicense()
        {
            return InternationalLicenseDA.GetAllLicenses();
        }        
        public static bool IsHasActiveLicense(int id)
        {
           return InternationalLicenseDA.IsPersonHasLicense(id);


        }

    }
}
