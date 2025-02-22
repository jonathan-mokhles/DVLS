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

        ApplicationTypesBuisness _typeBuisness = new ApplicationTypesBuisness();
        InternationalLicenseBusiness _internationalLicense =new InternationalLicenseBusiness();
        public InternationalLicenseApplication()
        {
            InitializeComponent();
            _type = _typeBuisness.GetType(6);
            this.lblDate.Text = DateTime.Now.ToString("d");
            this.lblIssue.Text = DateTime.Now.ToString("d");
            this.lblExpireDate.Text = DateTime.Now.AddYears(1).ToString("d");
            this.lblFees.Text = _type.Fees.ToString();
            this.lblUser.Text = GlobalSettings.CurrentUserID.ToString();


        }

 
        private void btnFind_Click_1(object sender, EventArgs e)
        {
            this.licenseInfoControlcs1.LoadForm(null, Convert.ToInt32(this.textBox1.Text));
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
            else if (_internationalLicense.IsHasActiveLicense(_licenses.PersonID))
            {
                MessageBox.Show("This person has international license", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int[] IDs = new int[2];

                IDs = _internationalLicense.CreateLincense(new InternationalLicense
                {
                    PersonID = _licenses.PersonID,
                    IssuedUsingLocalLicenseID = _licenses.LicenseID,
                    IssueDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddYears(1),
                    IsActive = true,
                    CreatedByUserID = GlobalSettings.CurrentUserID

                },_type.Fees);
                MessageBox.Show("Inernational license created successfully message", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.lblAppId.Text = IDs[0].ToString();
                this.lblLicenseId.Text = IDs[1].ToString();

            }
        }
    }
}
