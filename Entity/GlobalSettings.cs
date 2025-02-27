using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum FormMode
    {
        View,
        Add,
        Update
    }
    public enum ApplicationStatus
    {
        New = 1,
        Canceled,
        Completed,
    }
    public enum IssueReason
    {
        FirstTime = 1,
        Renew,
        ReplacementForDamaged,
        ReplacementForLost
    }
    public enum TestsResult
    {
        Failed,
        Passed,
        InProgress

    }
    public class GlobalSettings
    {
        public static User CurrentUser;
    }

}
