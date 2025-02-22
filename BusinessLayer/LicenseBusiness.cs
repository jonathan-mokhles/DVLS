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
        LicenseDA _licenseDA = new LicenseDA();
        LocalLicenseApplicationBusiness _application = new LocalLicenseApplicationBusiness();

        public int CreateLicense(DrivingLicense license)
        {
            return _licenseDA.InsertLicense(license);
        }
        public void UpdateLicense(int LicenseID, bool IsActive)
        {
            _licenseDA.UpdateLicense(LicenseID,IsActive);
        }
        public void DeleteLicense(int licenseID)
        {
            _licenseDA.DeleteLicense(licenseID);
        }
        public DrivingLicense GetLicenseByID(int licenseID)
        {
            return _licenseDA.GetLicenseByID(licenseID);
        }
        public DataTable GetAllLicenses()
        {
            return _licenseDA.GetAllLicenses();
        }
        public DataTable GetLicenseByAppID(int? appID = null, int? licenseID = null)
        {
            return _licenseDA.GetLicenseInfo(appID, licenseID);
        }

        public int[] RenewLicense(DrivingLicense license) {

            _licenseDA.UpdateLicense(license.LicenseID, false);


            int[] IDs = new int[2];

            IDs[0] = _application.AddApp(new LocalLicenseApplications
            {
              
               Application = new Applications
               {
                    PersonID = license.PersonID,
                    Date = license.IssueDate,
                    TypeID = 2,
                    Status = ApplicationStatus.Completed,
                    LastStatusDate = license.IssueDate,
                    PaidFees = license.PaidFees,
                    CreatedByUserId = GlobalSettings.CurrentUserID
                },
               classID = license.LicenseClassID
            });

            license.ApplicationID = IDs[0];

            IDs[1] = _licenseDA.InsertLicense(license);

            return IDs;
        }

    }
}
