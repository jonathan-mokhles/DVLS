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

    public enum Permissions
    {
        PeopleMangment = 1,
        UserMangment = 2,
        LicenseMangment = 4,
        TestMangment = 8

    }
    public class GlobalSettings
    {
        public static User CurrentUser;
    }

}
