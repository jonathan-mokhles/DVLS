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
        DrivingLicenseClassesDA classes = new DrivingLicenseClassesDA();


        public DataTable GetAllClasses()
        {
            return classes.GetAllClasses();
        }
        public LicenseClass GetClass(int id)
        {
            return classes.GetClassByID(id);
        }
    }
}
