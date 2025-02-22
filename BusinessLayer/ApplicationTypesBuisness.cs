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
        ApplicationTypesDA _applicationTypesAccess = new ApplicationTypesDA();

        public DataTable GetAllTypes()
        {
            return _applicationTypesAccess.GetAllApplicationTypes();
        }
        public bool EditApplicationType(ApplicationTypes type)
        {
            return _applicationTypesAccess.UpdateApplicationType(type);
        } 
        public ApplicationTypes GetType(int typeid)
        {
            return _applicationTypesAccess.GetTypeByID(typeid);
        }
    }
}
