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
        public int ApplicationID { get; set; }
        public int PersonID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public IssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsDetain { get; set; } 
    }
}
