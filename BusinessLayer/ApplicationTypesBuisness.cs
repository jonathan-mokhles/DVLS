using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace BusinessLayer
{
    public class ApplicationTypesBuisness
    {
        public static DataTable GetAllTypes()
        {
            return ApplicationTypesDA.GetAllApplicationTypes();
        }
        public static bool EditApplicationType(ApplicationTypes type)
        {
            return ApplicationTypesDA.UpdateApplicationType(type);
        } 
        public static ApplicationTypes GetType(int typeid)
        {
            return ApplicationTypesDA.GetTypeByID(typeid);
        }
    }
}
