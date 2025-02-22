using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CountriesDA
    {

        public DataTable GetCountries()
        {
            string query = "SELECT * FROM Countries"; 

            using (SqlConnection connection = new SqlConnection(connectionString.Value))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable countries = new DataTable();
                adapter.Fill(countries);
                return countries;
            }
        }
    }
}
