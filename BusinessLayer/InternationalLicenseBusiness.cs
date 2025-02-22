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
        InternationalLicenseDA licenseDA = new InternationalLicenseDA();
        ApplicationDA applicationDA = new ApplicationDA();

        public int[] CreateLincense(InternationalLicense license,decimal fees)
        {
            int[] IDs = new int[2];
            IDs[0] = applicationDA.AddApplication(new Applications
            {
                PersonID = license.PersonID,
                Date = license.IssueDate,
                TypeID = 6,
                Status = ApplicationStatus.Completed,
                LastStatusDate = license.IssueDate,
                CreatedByUserId = GlobalSettings.CurrentUserID,
                PaidFees = fees
            });
            license.ApplicationID = IDs[0];
            IDs[1] = licenseDA.CreateLicense(license);

            return IDs;

        }
        public void UpdateLicense(int LicenseID, bool IsActive)
        {
             licenseDA.UpdateLicense(LicenseID,IsActive);
        }
        public void DeleteLicense(int licenseId)
        {
             licenseDA.DeleteLicense(licenseId);
        }
        public DataTable GetLicenseByID(int licenseId)
        {
            return licenseDA.GetLicenseById(licenseId);
        }        
        public DataTable GetLAllLicense()
        {
            return licenseDA.GetAllLicenses();
        }        
        public bool IsHasActiveLicense(int id)
        {
           return licenseDA.GetLicenseByPersonId(id);


        }

    }
}
