using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcess_DVLD_;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace BusinessLayer
{
    public class ApplicationTypesBuisness
    {
        ApplicationTypesAccess _applicationTypesAccess = new ApplicationTypesAccess();

        public DataTable GetAllTypes()
        {
            return _applicationTypesAccess.GetAllApplicationTypes();
        }
        public bool EditApplicationType(DrivingApplicationType type)
        {
            return _applicationTypesAccess.UpdateApplicationType(type);
        }
    }
}
