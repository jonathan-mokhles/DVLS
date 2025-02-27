using BusinessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class RenewLicense : Form
    {
        DrivingLicense _licenses = null;




        public RenewLicense()
        {
            InitializeComponent();

            this.lblDate.Text = DateTime.Now.ToString("d");
            this.lblIssue.Text = DateTime.Now.ToString("d");
            this.lblUser.Text = GlobalSettings.CurrentUser.UserName;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.licenseInfoControlcs1.SetLicenseByID(Convert.ToInt32(this.textBox1.Text));
            _licenses = this.licenseInfoControlcs1.getLicenses();
            if (_licenses != null)
            {
                this.lblExpireDate.Text = DateTime.Now.AddYears(_licenses.Class.DefaultValidityLength).ToString("d");
                this.lblFees.Text = _licenses.Class.Fees.ToString();
                this.lblOldID.Text = _licenses.LicenseID.ToString();
                this.lblAppFees.Text = _licenses.Application.Type.Fees.ToString();

                this.lblTfees.Text = (_licenses.Class.Fees + _licenses.Application.Type.Fees).ToString();
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (_licenses == null)
            {
                MessageBox.Show("please write correct license ID", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (_licenses.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("The license is not yet expiared ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            else if (!_licenses.IsActive)
            {
                MessageBox.Show("The license is not Active ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int[] IDs = new int[2];

                DrivingLicense license = new DrivingLicense();
                license.LicenseID = _licenses.LicenseID;
                license.Application.person.PersonID = _licenses.Application.person.PersonID;
                license.Class.ID = _licenses.Class.ID;
                license.IssueDate = DateTime.Now;
                license.ExpirationDate = DateTime.Now.AddYears(_licenses.Class.DefaultValidityLength);
                license.Notes = null;
                license.PaidFees = _licenses.Class.Fees + _licenses.Application.Type.Fees;
                license.IsActive = true;
                license.IssueReason = IssueReason.Renew;
                license.CreatedByUser.UserId = GlobalSettings.CurrentUser.UserId;

                IDs = LicenseBusiness.RenewLicense(license);
                MessageBox.Show("Driving License Has Been Successfully Renewed ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _licenses.IsActive = false;
                this.lblAppId.Text = IDs[0].ToString();
                this.lblNewId.Text = IDs[1].ToString();

            }
        }
    }
}
