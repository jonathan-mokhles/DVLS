using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LocalLicenseApplications : Applications
    {
        public int LocalID { get; set; }
        public LicenseClass Class { get; set; }

        public LocalLicenseApplications() { Class = new LicenseClass();  }
        public void setApp (Applications app) {
            this.person =  app.person ;
            this.Date = app.Date ;
            this.Status = app.Status;
            this.LastStatusDate = app.LastStatusDate;
            this.CreatedByUser = app.CreatedByUser;
            this.Type = app.Type;
            this.ID = app.ID;
            this.PaidFees = app.PaidFees;

            }
    }
}
