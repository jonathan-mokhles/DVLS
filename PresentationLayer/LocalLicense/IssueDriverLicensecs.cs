using BusinessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class IssueDriverLicensecs : Form
    {
        LocalLicenseApplications _Localapplications;

        public IssueDriverLicensecs(int AppID)
        {
            InitializeComponent();
            _Localapplications = LocalLicenseApplicationBusiness.GetLocalApplication(AppID);
            this.localLicenseApplicationInfo1.SetApp(_Localapplications);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            DrivingLicense license = new DrivingLicense();
            license.Application.ID = _Localapplications.ID;
            license.Application.person.PersonID = _Localapplications.person.PersonID;
            license.Class.ID = _Localapplications.Class.ID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(_Localapplications.Class.DefaultValidityLength);
            license.Notes = null;
            license.PaidFees = _Localapplications.Class.Fees;
            license.IsActive = true;
            license.IssueReason = IssueReason.FirstTime;
            license.CreatedByUser.UserId = GlobalSettings.CurrentUser.UserId;

            int id = LicenseBusiness.CreateLicense(license);

            _Localapplications.Status = ApplicationStatus.Completed;
            _Localapplications.LastStatusDate = DateTime.Now;
            LocalLicenseApplicationBusiness.UpdateApp(_Localapplications);
            MessageBox.Show("License  created successfully! with ID "+id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
