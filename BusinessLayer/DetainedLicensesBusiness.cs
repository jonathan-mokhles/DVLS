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
        DetainedLicensesDA licensesDA = new DetainedLicensesDA();
        ApplicationBusiness applicationBusiness = new ApplicationBusiness();

        public int DetainLicense(int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID)
        {
            return licensesDA.CreateDetainedLicense(licenseID,detainDate, fineFees, createdByUserID);
        }
        public DataTable GetAll()
        {
            return licensesDA.GetAllDetainedLicenses();
        }

        public int ReleaseLicense(int detainID, int releasedByUserID, int PersonId,decimal AppFees)
        {
            int releaseApplicationID = applicationBusiness.AddApplication(new Applications
            {
                PersonID = PersonId,
                Date = DateTime.Now,
                TypeID = 5,
                Status = ApplicationStatus.Completed,
                LastStatusDate = DateTime.Now,
                PaidFees = AppFees,
                CreatedByUserId = releasedByUserID
            });

            licensesDA.UpdateDetainedLicense(detainID, true, DateTime.Now, releasedByUserID,releaseApplicationID);

            return releaseApplicationID;
        }

        public DataRow GetInfoByLicenseID(int licenseID)
        {
            return licensesDA.GetDetainedInfoByLicenseID(licenseID);
        }
    }
}
