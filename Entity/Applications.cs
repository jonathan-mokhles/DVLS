using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Applications
    {
        public int ID { get; set;}
        public int PersonID { get; set;}
        public String PersonName { get; set;}
        public int TypeID { get; set;}
        public String TypeName { get; set;}
        public int CreatedByUserId { get; set;}
        public String CreatedByUserName { get; set;}
        public DateTime Date { get; set;}
        public DateTime LastStatusDate { get; set;}
        public decimal PaidFees { get; set;}
        public ApplicationStatus Status { get; set; } //1-New 2-Cancelled 3-Completed

    }
}
