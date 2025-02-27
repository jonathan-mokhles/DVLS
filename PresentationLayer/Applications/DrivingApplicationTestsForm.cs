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
using System.Xml.Linq;

namespace DVLD
{
    public partial class DrivingApplicationTestsForm : Form
    {
        public DrivingApplicationTestsForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = TestsTypesBuisness.GetAllTests();
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
              EditDrivingLicenseTest editForm = new EditDrivingLicenseTest(new TestTypes
                {
                    ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TestTypeID"].Value),
                    Title = dataGridView1.SelectedRows[0].Cells["TestTypeTitle"].Value.ToString(),
                    Description = dataGridView1.SelectedRows[0].Cells["TestTypeDescription"].Value.ToString(),
                    Fees = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["TestTypeFees"].Value)
                });


                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.DataSource = TestsTypesBuisness.GetAllTests();
                }
            }
        }
    }
}
