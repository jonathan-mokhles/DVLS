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
    public class ApplicationTestsBuisness
    {
        ApplicationTestsAccess _applicationTestsAccess = new ApplicationTestsAccess();

        public DataTable GetAllTests()
        {
            return _applicationTestsAccess.GetAllTestTypes();
        }
        public bool EditApplicationTests(DrivingApplicationTests test)
        {
            return _applicationTestsAccess.UpdateTestType(test);
        }
    }
}
