using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class People
    {
        public string FirstName {  get; set; }
        public int ID {  get; set; }
        public string LastName {  get; set; }
        public string Address {  get; set; }
        public string Nationality {  get; set; }
        public string Email {  get; set; }
        public string ImagePath {  get; set; }
        public char Gender {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string Phone { get; set; }

        public People() { }
    }
}
