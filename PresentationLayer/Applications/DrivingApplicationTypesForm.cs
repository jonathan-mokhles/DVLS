using System;
using Entity;
using BusinessLayer;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class DrivingApplicationTypesForm : Form
    {
        public DrivingApplicationTypesForm()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = ApplicationTypesBuisness.GetAllTypes();
        }

        private void editTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDrivingLicenseTypes editDrinvingApplicationType = new EditDrivingLicenseTypes(new ApplicationTypes
            {
                ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value),
                Fees = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[2].Value),
                Title = dataGridView1.SelectedRows[0].Cells[1].Value.ToString()

            } );

            if(editDrinvingApplicationType.ShowDialog() == DialogResult.OK)
                this.dataGridView1.DataSource = ApplicationTypesBuisness.GetAllTypes();

        }
    }
}
