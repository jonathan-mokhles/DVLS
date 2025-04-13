using System;
using System.Collections.Generic;
using System.Data;
using DataAccess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BusinessLayer
{
    public class RolesBuisness
    {

        public static DataTable GetAllCountries()
        {
            return UserRolesDA.GetRoles();
        }
        public static Roles GetRole(int id)
        {
            return UserRolesDA.GetRoleById(id);
        }
    }
}
