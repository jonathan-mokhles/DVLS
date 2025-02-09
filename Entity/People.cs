using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class People
    {
        public int PersonID {  get; set; }
        public string FirstName {  get; set; }
        public string NationalNo {  get; set; }
        public string LastName {  get; set; }
        public string Address {  get; set; }
        public string Nationality {  get; set; }
        public string Email {  get; set; }
        public string ImagePath {  get; set; }
        public char Gender {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string Phone { get; set; }

        public People() {
            PersonID = -1;
            FirstName = "???";
            LastName = "???";
            Address = "???";
            NationalNo = "???";
            Email = "???";
            ImagePath = null;
            Nationality = "Egypt";
            Gender = 'M';
            Phone = "???";
            DateOfBirth = DateTime.Parse("1753-01-01");
        }
    }
}
