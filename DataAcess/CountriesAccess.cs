using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess_DVLD_
{
    public class CountriesAccess
    {
        static string connectionString = "Server=JONATHAN_MOKHLE\\MSQLSERVER;Database=DVLD;User=sa;Password=123456";

        public DataTable GetCountries()
        {
            string query = "SELECT * FROM Countries"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable countries = new DataTable();
                adapter.Fill(countries);
                return countries;
            }
        }
    }
}
