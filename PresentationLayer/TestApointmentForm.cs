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
    public partial class TestApointmentForm : Form
    {
        TestTypes TestType;
        LocalLicenseApplications applications;
        bool hasInProgress;
        bool hasPassed;

        TestsTypesBuisness tests = new TestsTypesBuisness();
        LocalLicenseApplicationBusiness LocalBusiness = new LocalLicenseApplicationBusiness();

        public TestApointmentForm(int testid, int appID)
        {
            InitializeComponent();

            TestType = tests.GetType(testid);
            applications = LocalBusiness.GetLocalApplication(appID);

            this.localLicenseApplicationInfo1.SetApp(applications);
            loadForm();

        }
        private void loadForm()
        {
            this.Text = $"{TestType.Title} Appointments";
            this.lblTitle.Text = $"{TestType.Title} Appointments";
            TestAppointmentBusiness test = new TestAppointmentBusiness();
            if (TestType.ID == 1)
            {
                pictureBox2.Image = Properties.Resources.VisionTest;
                dataGridView1.DataSource = test.GetTestAppointments(TestType.ID, applications.LocalID);
            }
            else if (TestType.ID == 2)
            {
                pictureBox2.Image = Properties.Resources.WrittenTest;
                dataGridView1.DataSource = test.GetTestAppointments(TestType.ID, applications.LocalID);
            }
            else if (TestType.ID == 3)
            {
                pictureBox2.Image = Properties.Resources.DrivingTest;
                dataGridView1.DataSource = test.GetTestAppointments(TestType.ID, applications.LocalID);
            }
             hasInProgress = dataGridView1.Rows.Cast<DataGridViewRow>()
            .Any(row => row.Cells["Status"].Value.ToString() == "InProgress");
            hasPassed = dataGridView1.Rows.Cast<DataGridViewRow>()
            .Any(row => row.Cells["Status"].Value.ToString() == "Passed");


        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (hasInProgress)
                MessageBox.Show("there is appointment in progress for this test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (hasPassed)
                MessageBox.Show(" passed the test you can not retake the test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
               MakeTestAppointment form = new MakeTestAppointment(TestType, applications.LocalID, this.dataGridView1.RowCount);
               form.ShowDialog();
                loadForm();
           }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            MakeTestAppointment form = new MakeTestAppointment(TestType, applications.LocalID, this.dataGridView1.RowCount,id);
            form.ShowDialog();
            loadForm();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            TakeTest form = new TakeTest(id, this.dataGridView1.RowCount);
            form.ShowDialog();
            loadForm();

        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "InProgress")
            {
                this.editToolStripMenuItem.Enabled = true;
                this.takeTestToolStripMenuItem.Enabled = true;
            }
        }
    }
}
