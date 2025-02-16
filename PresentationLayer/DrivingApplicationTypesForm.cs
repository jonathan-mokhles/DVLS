using System;
using Entity;
using BusinessLayer;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class DrivingApplicationTypesForm : Form
    {
        ApplicationTypesBuisness _applicationTypeBuisness = new ApplicationTypesBuisness();
        public DrivingApplicationTypesForm()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = _applicationTypeBuisness.GetAllTypes();
        }

        private void editTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDrivingLicenseTypes editDrinvingApplicationType = new EditDrivingLicenseTypes(new DrivingApplicationType
            {
                ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ApplicationTypeID"].Value),
                Fees = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["ApplicationFees"].Value),
                Title = dataGridView1.SelectedRows[0].Cells["ApplicationTypeTitle"].Value.ToString()

            } );

            if(editDrinvingApplicationType.ShowDialog() == DialogResult.OK)
                this.dataGridView1.DataSource = _applicationTypeBuisness.GetAllTypes();

        }
    }
}
