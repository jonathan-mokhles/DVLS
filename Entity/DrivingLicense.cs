using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DrivingLicense
    {
        public int LicenseID { get; set; }
        public Applications Application { get; set; }
        public LicenseClass Class { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public IssueReason IssueReason { get; set; }
        public User CreatedByUser { get; set; }
        public bool IsDetain { get; set; } 

        public DrivingLicense() {
            Application = new Applications();
            Class = new LicenseClass();
            CreatedByUser = new User();
        }
        public void  setApp (LocalLicenseApplications app) {
            this.Application = app;
            this.Class = app.Class;
        }
    }
}
