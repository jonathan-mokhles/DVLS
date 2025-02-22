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

        public void LoadForm(int? AppId, int? licenseID = null)
        {
            table = _licenseBusiness.GetLicenseByAppID(AppId, licenseID);
            if (table.Rows.Count != 0)
            {
                DataRow row = table.Rows[0];
                licenses = new DrivingLicense
                {
                    LicenseID = (int)row["LicenseID"],
                    ApplicationID = (int)row["ApplicationID"],
                    PersonID = (int)row["PersonID"],
                    LicenseClassID = (int)row["LicenseClassID"],
                    IssueDate = (DateTime)row["IssueDate"],
                    ExpirationDate = (DateTime)row["ExpirationDate"],
                    Notes = (object)row["Notes"] == DBNull.Value? null : (string)row["Notes"],
                    PaidFees = (decimal)row["PaidFees"],
                    IsActive = (bool)row["IsActive"],
                    IssueReason = (IssueReason)Convert.ToInt32(row["IssueReason"]),
                    CreatedByUserID = (int)row["CreatedByUserID"],
                    IsDetain = row["IsDetain"] != DBNull.Value ? true : false
                };

                this.lblClass.Text = row["ClassName"].ToString();
                this.lblName.Text = row["FullName"].ToString();
                this.lblLicenseId.Text = licenses.LicenseID.ToString();
                this.lblNational.Text = row["NationalNo"].ToString();
                this.lblGender.Text = row["Gender"].ToString();
                this.lblIssueDate.Text = licenses.IssueDate.ToString("MM/dd/yyyy");
                this.lblExpiryDate.Text = licenses.ExpirationDate.ToString("MM/dd/yyyy");
                this.lblIssueReason.Text = licenses.IssueReason.ToString();
                this.lblNotes.Text = licenses.Notes;
                this.lblIsActive.Text = licenses.IsActive? "Yes" : "No";
                this.lblDetain.Text = licenses.IsDetain? "Yes" : "No";
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
            else
            {
                MessageBox.Show("no");
            }
        }

        public DrivingLicense getLicenses()
        {
            return licenses;
        }

     }
}
