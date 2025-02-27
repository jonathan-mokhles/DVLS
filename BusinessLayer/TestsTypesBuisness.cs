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
    public class TestsTypesBuisness
    {
        public static DataTable GetAllTests()
        {
            return TestsTypesDA.GetAllTestTypes();
        }
        public static bool EditApplicationTests(TestTypes test)
        {
            return TestsTypesDA.UpdateTestType(test);
        }
        public static TestTypes GetType(int id)
        {
            return TestsTypesDA.GetTestByID(id);
        }
    }
}
