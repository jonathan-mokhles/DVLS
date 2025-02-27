using System;
using Entity;
using BusinessLayer;
using System.Windows.Forms;

namespace DVLD
{
    public partial class EditDrivingLicenseTest : Form
    {
        public EditDrivingLicenseTest(TestTypes test)
        {
            InitializeComponent();
            this.tbDescription.Text = test.Description;
            this.tbName.Text = test.Title;
            this.tbFees.Text =  test.Fees.ToString();
            this.lblID.Text = test.ID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
            bool success = TestsTypesBuisness.EditApplicationTests(new TestTypes
            {
                ID = Convert.ToInt32(lblID.Text),
                Title = tbName.Text,
                Description = tbDescription.Text,
                Fees = Convert.ToDecimal(tbFees.Text),
            });

            if (success)
            {
                MessageBox.Show("Update successful!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Update failed.");
            }
        }
    }
}
