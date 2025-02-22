using System;
using DataAccess;
using Entity;
using System.Data;

namespace BusinessLayer
{
    public class PeopleBusiness
    {
        PeopleDA peopleAccess = PeopleDA.getPeopleAccess();
        
        public int AddPerson(People person)
        {
            return peopleAccess.AddPerson(person);
        }
        public int DeletePerson(int id)
        {
            return peopleAccess.DeletePerson(id);
        }
        public int UpdatePerson(People person)
        {
            return peopleAccess.UpdatePerson(person);
        } 
        public DataTable GetAllPeople()
        {
            return peopleAccess.GetAllPeople();
        }
        public bool isUniqueNum(string num)
        {
            return peopleAccess.isUniqueNationalNo(num);
        }
        public People GetPerson(int id) {

            return peopleAccess.GetPersonByID(id);

        }
        public People GetPerson(string No) {

            return peopleAccess.GetPersonByNo(No);

        }
    }
}
