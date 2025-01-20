using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccess
{
    internal class PeopleAccess
    {
        private static PeopleAccess peopleAccess;
        private PeopleAccess() { }
        public static PeopleAccess getPeopleAccess()
        {
            if(peopleAccess == null)
            {
                peopleAccess = new PeopleAccess();
            }
            return peopleAccess;

        }


    }

}
