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

        CountriesDA countries = new CountriesDA();
        public DataTable GetAllCountries()
        {
            return countries.GetCountries();
        }
    }
}
