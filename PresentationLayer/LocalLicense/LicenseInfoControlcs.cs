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
    public partial class LicenseInfoControlcs : UserControl
    {
        DataTable table = new DataTable();
        LicenseBusiness _licenseBusiness = new LicenseBusiness();
        DrivingLicense licenses = null ;
        public LicenseInfoControlcs()
        {
            InitializeComponent();
        }

        public void SetLicenseByID(int licenseID)
        {
            licenses = LicenseBusiness.GetLicenseByID(licenseID);
            LoadForm();
        }
        public void SetLicenseByAppID(int AppId)
        {
            licenses = LicenseBusiness.GetLicenseByAppID(AppId);
            LoadForm();
        }
        private void LoadForm()
        {
            if (licenses != null)
            {
                this.lblClass.Text = licenses.Class.Name;
                this.lblName.Text = licenses.Application.person.FirstName +" "+ licenses.Application.person.LastName;
                this.lblLicenseId.Text = licenses.LicenseID.ToString();
                this.lblNational.Text = licenses.Application.person.NationalNo;
                this.lblGender.Text = licenses.Application.person.Gender.ToString();
                this.lblIssueDate.Text = licenses.IssueDate.ToString("dd/mm/yyyy");
                this.lblExpiryDate.Text = licenses.ExpirationDate.ToString("dd/mm/yyyy");
                this.lblIssueReason.Text = licenses.IssueReason.ToString();
                this.lblNotes.Text = licenses.Notes;
                this.lblIsActive.Text = licenses.IsActive? "Yes" : "No";
                this.lblDetain.Text = licenses.IsDetain? "Yes" : "No";
                this.lblDateOfBirth.Text = licenses.Application.person.DateOfBirth.ToString("dd/mm/yyyy");

                if (string.IsNullOrEmpty(licenses.Application.person.ImagePath))
                {
                    if (licenses.Application.person.Gender == 'M')
                        pictureBox1.Image = Properties.Resources.male;
                    else
                        pictureBox1.Image = Properties.Resources.female;
                }
                else
                    pictureBox1.ImageLocation = licenses.Application.person.ImagePath;
            }
            else
            {
                MessageBox.Show("Wrong license No.");
            }
        }

        public DrivingLicense getLicenses()
        {
            return licenses;
        }

     }
}
