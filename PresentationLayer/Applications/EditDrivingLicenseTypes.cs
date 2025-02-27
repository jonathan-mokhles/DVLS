using System;
using Entity;
using BusinessLayer;
using System.Windows.Forms;

namespace DVLD
{
    
    public partial class EditDrivingLicenseTypes : Form
    {
        public EditDrivingLicenseTypes(ApplicationTypes _type)
        {
            InitializeComponent();
            this.tbName.Text = _type.Title;
            this.tbFees.Text = _type.Fees.ToString();
            this.lblID.Text = _type.ID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(
                ApplicationTypesBuisness.EditApplicationType(new ApplicationTypes
                {
                    ID = int.Parse(lblID.Text),
                    Fees = decimal.Parse(tbFees.Text),
                    Title = tbName.Text
                })

                )
            {
                MessageBox.Show("Update successful!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Update failed.");
        }
    }
}
