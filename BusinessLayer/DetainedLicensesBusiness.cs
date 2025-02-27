using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entity;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class DetainedLicensesBusiness
    {
        public static  int DetainLicense(int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID)
        {
            return DetainedLicensesDA.CreateDetainedLicense(licenseID,detainDate, fineFees, createdByUserID);
        }
        public DataTable GetAll()
        {
            return DetainedLicensesDA.GetAllDetainedLicenses();
        }

        public static int ReleaseLicense(int detainID, int releasedByUserID, int PersonId,decimal AppFees)
        {
            Applications app = new Applications();
            app.person.PersonID = PersonId;
            app.Date = DateTime.Now;
            app.Type.ID = 5;
            app.Status = ApplicationStatus.Completed;
            app.LastStatusDate = DateTime.Now;
            app.PaidFees = AppFees;
            app.CreatedByUser.UserId = releasedByUserID;
            int releaseApplicationID = ApplicationBusiness.AddApplication(app);

            DetainedLicensesDA.UpdateDetainedLicense(detainID, true, DateTime.Now, releasedByUserID,releaseApplicationID);

            return releaseApplicationID;
        }

        public static DataRow GetInfoByLicenseID(int licenseID)
        {
            return DetainedLicensesDA.GetDetainedInfoByLicenseID(licenseID);
        }
    }
}
