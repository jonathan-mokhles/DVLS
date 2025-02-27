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
    public partial class ReplacementLicense : Form
    {
        ApplicationTypes _type;

        DrivingLicense _licenses = null;
        public ReplacementLicense()
        {
            InitializeComponent();
            this.lblDate.Text = DateTime.Now.ToString("d");
            this.lblUser.Text = GlobalSettings.CurrentUser.UserName;

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.licenseInfoControlcs1.SetLicenseByID(Convert.ToInt32(this.textBox1.Text));
            _licenses = this.licenseInfoControlcs1.getLicenses();
            if (_licenses != null)
            {
                this.lblOldID.Text = _licenses.LicenseID.ToString();
            }
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamaged.Checked) 
                _type = ApplicationTypesBuisness.GetType(4);
            else
                _type = ApplicationTypesBuisness.GetType(3);

            this.lblAppFees.Text = _type.Fees.ToString();


        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (_licenses == null)
            {
                MessageBox.Show("please write correct license ID", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!_licenses.IsActive)
            {
                MessageBox.Show("The license is not Active ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int[] IDs = new int[2];
                _licenses.IssueReason = _type.ID == 3 ? IssueReason.ReplacementForLost : IssueReason.ReplacementForDamaged;
                _licenses.CreatedByUser = GlobalSettings.CurrentUser;
                _licenses.PaidFees = _type.Fees;
                IDs = LicenseBusiness.RenewLicense(_licenses);
                MessageBox.Show("Driving License Has Been Successfully Renewed ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _licenses.IsActive = false;
                this.lblAppId.Text = IDs[0].ToString();
                this.lblNewId.Text = IDs[1].ToString();

            }
        }
    }
}
