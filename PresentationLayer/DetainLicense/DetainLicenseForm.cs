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
    public partial class DetainLicenseForm : Form
    {
        DrivingLicense _licenses = null;

        public DetainLicenseForm()
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
                this.lblLicenseId.Text = _licenses.LicenseID.ToString();
            }
        }

  
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (_licenses == null)
            {
                MessageBox.Show("please write correct license ID", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (_licenses.IsDetain)
            {
                MessageBox.Show("The license is not already detained ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int ID = DetainedLicensesBusiness.DetainLicense(_licenses.LicenseID,DateTime.Now,Convert.ToInt32(this.tbFees.Text),GlobalSettings.CurrentUser.UserId) ;
                MessageBox.Show("License Has Been Successfully Detained ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _licenses.IsDetain = true;
                this.lblAppId.Text = ID.ToString();

            }
        }
    }
}
