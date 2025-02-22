using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace DVLD
{
    public partial class LocalLicenseApplicationManagment : Form
    {
        LocalLicenseApplicationBusiness App = new LocalLicenseApplicationBusiness();
        public LocalLicenseApplicationManagment()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = App.GetAll();
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                ApplicationLicenseForm form = new ApplicationLicenseForm();
                form.SetMode(FormMode.View, id);
                form.ShowDialog();
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int ID = App.GetLocalApplication(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)).Application.ID;
                ApplicationStatus Status = ApplicationStatus.Canceled;
                DateTime LastStatusDate = DateTime.Now;
                App.AppBusiness.UpdateApplication(ID, Status, LastStatusDate);

                this.dataGridView1.DataSource = App.GetAll();

            }

        }



        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this Application?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    App.DeleteApp(id);
                    this.dataGridView1.DataSource = App.GetAll();
                }
            }
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    string Status = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            //    int passedTests = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
            //    if (Status == "New")
            //    {
            //        switch (passedTests)
            //        {
            //            case 0:
            //                this.msVisionTest.Enabled = true;
            //                break;
            //            case 1:
            //                this.msWrittenTest.Enabled = true;
            //                break;
            //            case 2:
            //                this.msPracticalTest.Enabled = true;
            //                break;
            //            case 3:
            //                this.msIssueDrivingLicense.Enabled = true;
            //                break;

            //        }
            //    }
            //    else if (Status == "Canceled")
            //    {
            //        this.msCancelApplication.Enabled = false;
            //        this.msScheduleTest.Enabled = false;
            //    }
            //    else if (Status == "Completed")
            //    {
            //        this.msCancelApplication.Enabled = false;
            //        this.msScheduleTest.Enabled = false;
            //        this.msShowDrivingLicense.Enabled = true;
            //    }
            //}
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                TestApointmentForm test = new TestApointmentForm(1, ID);
                test.ShowDialog();
                this.dataGridView1.DataSource = App.GetAll();

            }
        }
        private void msWrittenTest_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                TestApointmentForm test = new TestApointmentForm(2, ID);
                test.ShowDialog();
                this.dataGridView1.DataSource = App.GetAll();

            }
        }

        private void msPracticalTest_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                TestApointmentForm test = new TestApointmentForm(3, ID);
                test.ShowDialog();
                this.dataGridView1.DataSource = App.GetAll();

            }
        }

        private void msIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            IssueDriverLicensecs form = new IssueDriverLicensecs(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            form.ShowDialog();
            this.dataGridView1.DataSource = App.GetAll();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string Status = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                int passedTests = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);
                if (Status == "New")
                {
                    switch (passedTests)
                    {
                        case 0:
                            this.msVisionTest.Enabled = true;
                            break;
                        case 1:
                            this.msWrittenTest.Enabled = true;
                            break;
                        case 2:
                            this.msPracticalTest.Enabled = true;
                            break;
                        case 3:
                            this.msIssueDrivingLicense.Enabled = true;
                            break;

                    }
                }
                else if (Status == "Canceled")
                {
                    this.msCancelApplication.Enabled = false;
                    this.msScheduleTest.Enabled = false;
                    this.msEditApplication.Enabled = false;

                }
                else if (Status == "Completed")
                {
                    this.msScheduleTest.Enabled = false;
                    this.msDeleteApplication.Enabled = false;
                    this.msCancelApplication.Enabled = false;
                    this.msScheduleTest.Enabled = false;
                    this.msShowDrivingLicense.Enabled = true;
                    this.msEditApplication.Enabled = false;
                }
            }

        }

        private void msShowDrivingLicense_Click(object sender, EventArgs e)
        {
            LicenseInfoForm form = new LicenseInfoForm(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            form.ShowDialog();
        }
    }
}
