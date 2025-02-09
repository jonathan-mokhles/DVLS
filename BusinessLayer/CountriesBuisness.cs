using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CountriesBuisness
    {

        CountriesAccess countries = new CountriesAccess();
        public DataTable GetAllCountries()
        {
            return countries.GetCountries();
        }
    }
}
