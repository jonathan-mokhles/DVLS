using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD
{
    public enum FormMode
    {
        View,
        Add,
        Update
    }
    public class GlobalSettings
    {
        public static int CurrentUserID;
    }

}
