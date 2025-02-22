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
        ApplicationTypes _type;
        ApplicationTypesBuisness _typeBuisness = new ApplicationTypesBuisness();

        DrivingLicense _licenses = null;
        LicenseBusiness _licenseBusiness = new LicenseBusiness();

        LicenseClass _Class = new LicenseClass();
        DrivinglicenseClassesBuisness _ClassesBuisness = new DrivinglicenseClassesBuisness();



        public RenewLicense()
        {
            _type = _typeBuisness.GetType(2);
            InitializeComponent();

            this.lblDate.Text = DateTime.Now.ToString("d");
            this.lblIssue.Text = DateTime.Now.ToString("d");
            this.lblUser.Text = GlobalSettings.CurrentUserID.ToString();
            this.lblAppFees.Text = _type.Fees.ToString();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.licenseInfoControlcs1.LoadForm(null, Convert.ToInt32(this.textBox1.Text));
            _licenses = this.licenseInfoControlcs1.getLicenses();
            if (_licenses != null)
            {
                _Class = _ClassesBuisness.GetClass(_licenses.LicenseClassID);
                this.lblExpireDate.Text = DateTime.Now.AddYears(_Class.DefaultValidityLength).ToString("d");
                this.lblFees.Text = _Class.Fees.ToString();
                this.lblOldID.Text = _licenses.LicenseID.ToString();
                this.lblTfees.Text = (_Class.Fees + _type.Fees).ToString();
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

                IDs = _licenseBusiness.RenewLicense (new DrivingLicense
                {
                    LicenseID = _licenses.LicenseID,
                    PersonID = _licenses.PersonID,
                    LicenseClassID = _licenses.LicenseClassID,
                    IssueDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddYears(_Class.DefaultValidityLength),
                    Notes = null,
                    PaidFees = _Class.Fees + _type.Fees,
                    IsActive = true,
                    IssueReason = IssueReason.Renew,
                    CreatedByUserID = GlobalSettings.CurrentUserID

                });
                MessageBox.Show("Driving License Has Been Successfully Renewed ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _licenses.IsActive = false;
                this.lblAppId.Text = IDs[0].ToString();
                this.lblNewId.Text = IDs[1].ToString();

            }
        }
    }
}
