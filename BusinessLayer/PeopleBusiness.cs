using System;
using DataAccess;
using Entity;
using System.Data;

namespace BusinessLayer
{
    public class PeopleBusiness
    {
       
        public static int AddPerson(People person)
        {
            return PeopleDA.AddPerson(person);
        }
        public static int DeletePerson(int id)
        {
            return PeopleDA.DeletePerson(id);
        }
        public static int UpdatePerson(People person)
        {
            return PeopleDA.UpdatePerson(person);
        } 
        public static DataTable GetAllPeople()
        {
            return PeopleDA.GetAllPeople();
        }
        public static bool isUniqueNum(string num)
        {
            return PeopleDA.isUniqueNationalNo(num);
        }
        public static People GetPerson(int id) {

            return PeopleDA.GetPersonByID(id);

        }
        public static People GetPerson(string No) {

            return PeopleDA.GetPersonByNo(No);

        }
    }
}
