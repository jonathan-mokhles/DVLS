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
        public Roles Role {  get; set; }
        public bool IsActive {  get; set; }

        public User() { person = new People(); }
        public User(People person)
        {
            this.person = person;
          
        }
    }
    
}
