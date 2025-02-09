using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public People person { get; set; }
        public int UserId { get; set; }
        public string UserName {  get; set; }
        public string Password {  get; set; }
        public int Role {  get; set; }
        public bool IsActive {  get; set; }

        public User() { }
        public User(People person)
        {
            this.person = person;
          
        }
    }
    
}
