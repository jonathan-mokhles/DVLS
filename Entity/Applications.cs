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
        public People person { get; set;}
        public ApplicationTypes Type { get; set;}
        public User CreatedByUser { get; set;}
        public DateTime Date { get; set;}
        public DateTime LastStatusDate { get; set;}
        public decimal PaidFees { get; set;}
        public ApplicationStatus Status { get; set; } //1-New 2-Cancelled 3-Completed

        public Applications()
        {
            person = new People();
            Type = new ApplicationTypes();
            CreatedByUser = new User();
        }
    }
}
