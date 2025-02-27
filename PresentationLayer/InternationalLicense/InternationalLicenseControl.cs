using BusinessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class InternationalLicenseControl : UserControl
    {
        InternationalLicense license = new InternationalLicense();
        public InternationalLicenseControl()
        {
            InitializeComponent();
        }
        public void LoadForm(int licenseID )
        {
            license = InternationalLicenseBusiness.GetLicenseByID(licenseID);
            if (license != null)
            {

                this.lblName.Text = license.Application.person.FirstName + " " + license.Application.person.LastName;
                this.lblLicenseId.Text = license.InternationalLicenseID.ToString();
                this.lbllocalID.Text = license.IssuedUsingLocalLicenseID.ToString();
                this.lblNational.Text = license.Application.person.NationalNo;
                this.lblGender.Text = license.Application.person.Gender.ToString();
                this.lblIssueDate.Text = license.IssueDate.ToString("d");
                this.lblExpiryDate.Text = license.ExpirationDate.ToString("d");
                this.lblAppid.Text = license.Application.ID.ToString();
                this.lblIsActive.Text = license.IsActive.ToString();
               this.lblDateOfBirth.Text = license.Application.person.DateOfBirth.ToString("d");

                if (string.IsNullOrEmpty(license.Application.person.ImagePath))
                {
                    if (lblGender.Text == "M")
                        pictureBox1.Image = Properties.Resources.male;
                    else
                        pictureBox1.Image = Properties.Resources.female;
                }
                else
                    pictureBox1.ImageLocation = license.Application.person.ImagePath;
            }
        }

    }
}
