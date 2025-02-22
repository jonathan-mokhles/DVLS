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
        LocalLicenseApplications _applications;
        LicenseClass _licenseClass;

        LocalLicenseApplicationBusiness _LocalBusiness = new LocalLicenseApplicationBusiness();
        LicenseBusiness _licenseBusiness = new LicenseBusiness();
        DrivinglicenseClassesBuisness classesBuisness = new DrivinglicenseClassesBuisness();

        public IssueDriverLicensecs(int AppID)
        {
            InitializeComponent();
            _applications = _LocalBusiness.GetLocalApplication(AppID);
            _licenseClass = classesBuisness.GetClass(_applications.classID);
            this.localLicenseApplicationInfo1.SetApp(_applications);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int id = _licenseBusiness.CreateLicense(new DrivingLicense
            {
                ApplicationID = _applications.Application.ID,
                PersonID = _applications.Application.PersonID,
                LicenseClassID = _applications.classID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(_licenseClass.DefaultValidityLength),
                Notes = null,
                PaidFees = _licenseClass.Fees,
                IsActive = true,
                IssueReason = IssueReason.FirstTime,
                CreatedByUserID = GlobalSettings.CurrentUserID
            });
            _applications.Application.Status = ApplicationStatus.Completed;
            _applications.Application.LastStatusDate = DateTime.Now;
            _LocalBusiness.UpdateApp(_applications);
            MessageBox.Show("License  created successfully! with ID "+id, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
