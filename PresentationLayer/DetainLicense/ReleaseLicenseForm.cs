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

namespace DVLD.DetainLicense
{
    public partial class ReleaseLicenseForm : Form
    {
        DrivingLicense _licenses = null;

        ApplicationTypes _type;

        public ReleaseLicenseForm()
        {
            InitializeComponent();
            this.lblDate.Text = DateTime.Now.ToString("d");
            this.lblUser.Text = GlobalSettings.CurrentUser.UserName;
            _type = ApplicationTypesBuisness.GetType(5);


        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.btnRelease.Enabled = false;
            this.licenseInfoControlcs1.SetLicenseByID(Convert.ToInt32(this.textBox1.Text));
            _licenses = this.licenseInfoControlcs1.getLicenses();
            if (_licenses == null)
            {
                MessageBox.Show("please write correct license ID", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!_licenses.IsDetain)
            {
                MessageBox.Show("The license is not detained ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = DetainedLicensesBusiness.GetInfoByLicenseID(_licenses.LicenseID);

                this.lblDetainID.Text = row["DetainID"].ToString();
                this.lblDate.Text = row["DetainDate"].ToString();
                this.lblLicenseId.Text = row["LicenseID"].ToString();
                this.lblFees.Text = row["FineFees"].ToString();
                this.lblAppFees.Text = _type.Fees.ToString();
                this.lblUser.Text = row["CreatedByUserID"].ToString();
                this.lblTfees.Text = (_type.Fees + (decimal)row["FineFees"]).ToString();
                this.btnRelease.Enabled = true;

            }
        }

  
        private void btnRelease_Click(object sender, EventArgs e)
        {
            int ID = DetainedLicensesBusiness.ReleaseLicense(Convert.ToInt32(this.lblDetainID.Text),GlobalSettings.CurrentUser.UserId,_licenses.Application.person.PersonID,_type.Fees) ;
            MessageBox.Show("License Has Been Successfully Released ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _licenses.IsDetain = false;
            this.lblAppId.Text = ID.ToString();
        }
    }
}
