using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRolesDA
    {
        static public DataTable GetRoles()
        {
            string query = " select * from Roles";
            using (SqlConnection conn = new SqlConnection(connectionString.Value))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable Roles = new DataTable();
                adapter.Fill(Roles);
                return Roles;
            }
        }

        static public Roles GetRoleById(int id)
        {

            string query = " select * from Roles where ID = @id ";

            using (SqlConnection conn = new SqlConnection(connectionString.Value))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id",id);

                Roles role = new Roles();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    role.Id = (int)reader["ID"];
                    role.Name = (string)reader["RoleName"];
                    role.Permissions = (int)reader["Permissions"];

                }
                return role;

            }
        }
    }
}
