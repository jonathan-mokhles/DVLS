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
        TestsTypesDA _applicationTestsAccess = new TestsTypesDA();

        public DataTable GetAllTests()
        {
            return _applicationTestsAccess.GetAllTestTypes();
        }
        public bool EditApplicationTests(TestTypes test)
        {
            return _applicationTestsAccess.UpdateTestType(test);
        }
        public TestTypes GetType(int id)
        {
            return _applicationTestsAccess.GetTestByID(id);
        }
    }
}
