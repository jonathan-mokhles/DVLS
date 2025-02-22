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
    public partial class InternationalLicenseControl : UserControl
    {
        InternationalLicenseBusiness _licenseBusiness = new InternationalLicenseBusiness();
        DataTable table = new DataTable();

        public InternationalLicenseControl()
        {
            InitializeComponent();
        }
        public void LoadForm(int licenseID )
        {
            table = _licenseBusiness.GetLicenseByID(licenseID);
            if (table != null)
            {
                DataRow row = table.Rows[0];

                this.lblName.Text = row["FullName"].ToString();
                this.lblLicenseId.Text = row["InternationalLicenseID"].ToString();
                this.lbllocalID.Text = row["IssuedUsingLocalLicenseID"].ToString();
                this.lblNational.Text = row["NationalNo"].ToString();
                this.lblGender.Text = row["Gender"].ToString();
                this.lblIssueDate.Text = ((DateTime)row["IssueDate"]).ToString("MM/dd/yyyy");
                this.lblExpiryDate.Text = ((DateTime)row["ExpirationDate"]).ToString("MM/dd/yyyy");
                this.lblAppid.Text = row["ApplicationID"].ToString();
                this.lblIsActive.Text = row["IsActive"].ToString();
                this.lblDateOfBirth.Text = ((DateTime)row["DateOfBirth"]).ToString("MM/dd/yyyy");

                if (string.IsNullOrEmpty(row["ImagePath"].ToString()))
                {
                    if (lblGender.Text == "Male")
                        pictureBox1.Image = Properties.Resources.male;
                    else
                        pictureBox1.Image = Properties.Resources.female;
                }
                else
                    pictureBox1.ImageLocation = row["ImagePath"].ToString();
            }
        }

    }
}
