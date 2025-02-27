using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InternationalLicense
    {
        public int InternationalLicenseID { get; set; }
        public Applications Application { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public User CreatedByUser { get; set; }
        public InternationalLicense()
        {
            Application = new Applications();
            CreatedByUser = new User();
        }
    }
}
