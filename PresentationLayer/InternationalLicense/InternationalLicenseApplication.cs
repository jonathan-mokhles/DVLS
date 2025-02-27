using BusinessLayer;
using Entity;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class InternationalLicenseApplication : Form
    {

        ApplicationTypes _type;
        DrivingLicense _licenses = null;

        public InternationalLicenseApplication()
        {
            InitializeComponent();
            _type = ApplicationTypesBuisness.GetType(6);
            this.lblDate.Text = DateTime.Now.ToString("d");
            this.lblIssue.Text = DateTime.Now.ToString("d");
            this.lblExpireDate.Text = DateTime.Now.AddYears(1).ToString("d");
            this.lblFees.Text = _type.Fees.ToString();
            this.lblUser.Text = GlobalSettings.CurrentUser.UserName;


        }

 
        private void btnFind_Click_1(object sender, EventArgs e)
        {
            this.licenseInfoControlcs1.SetLicenseByID(Convert.ToInt32(this.textBox1.Text));
            _licenses = this.licenseInfoControlcs1.getLicenses();
            if(_licenses != null)
                this.lblllID.Text = _licenses.LicenseID.ToString();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
             if (_licenses == null)
            {
                MessageBox.Show("please write correct license ID", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }   
            else if(!_licenses.IsActive)
            {
                MessageBox.Show("The local license is not active", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            else if(_licenses.Class.ID != 3)
            {
                MessageBox.Show("The local license is not class 3", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (InternationalLicenseBusiness.IsHasActiveLicense(_licenses.Application.person.PersonID))
            {
                MessageBox.Show("This person has international license", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int[] IDs = new int[2];

                InternationalLicense license = new InternationalLicense();
                license.Application.person.PersonID = _licenses.Application.person.PersonID;
                license.IssuedUsingLocalLicenseID = _licenses.LicenseID;
                license.IssueDate = DateTime.Now;
                license.ExpirationDate = DateTime.Now.AddYears(1);
                license.IsActive = true;
                license.CreatedByUser = GlobalSettings.CurrentUser;
                IDs = InternationalLicenseBusiness.CreateLincense(license, _type.Fees);
                MessageBox.Show("Inernational license created successfully message", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.lblAppId.Text = IDs[0].ToString();
                this.lblLicenseId.Text = IDs[1].ToString();

            }
        }
    }
}
