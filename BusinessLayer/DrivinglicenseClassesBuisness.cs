using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace BusinessLayer
{
    public class DrivinglicenseClassesBuisness
    {

        public static DataTable GetAllClasses()
        {
            return DrivingLicenseClassesDA.GetAllClasses();
        }
        public static LicenseClass GetClass(int id)
        {
            return DrivingLicenseClassesDA.GetClassByID(id);
        }
    }
}
