using Entity;
using System;
using BusinessLayer;
using System.Windows.Forms;

namespace DVLD
{
    public partial class MakeTestAppointment : Form
    {
        TestTypes TestType;
        int AppID, Trails,Retake;
        int AppointmentID;
        public MakeTestAppointment(TestTypes test,int appID,int trails,int appointmentId = -1)
        {
            TestType = test;
            AppID = appID;
            Trails = trails;
            AppointmentID = appointmentId;


            InitializeComponent();
            RetakeTestLoad();
            SetForm();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (AppointmentID == -1)
            {
                if(Trails == 0)
                    TestAppointmentBusiness.CreateTestAppointment(GetAppointment());
                else
                    TestAppointmentBusiness.CreateRetakeTestAppointment(GetAppointment(), Retake);

            }
            else
                TestAppointmentBusiness.UpdateTestAppointment(GetAppointment());
            MessageBox.Show("Added successfully");
            this.Close();
        }
        private void RetakeTestLoad()
        {
            if (Trails > 0)
            {
                Retake = (int)ApplicationTypesBuisness.GetType(7).Fees;
            }
        }
        private void SetForm()
        {
            this.Text = $"{TestType.ToString()} Test schedule";
            if (TestType.ID == 1)
                pictureBox1.Image = Properties.Resources.VisionTest;

            else if (TestType.ID == 2)
                pictureBox1.Image = Properties.Resources.WrittenTest;

            else if (TestType.ID == 3)
                pictureBox1.Image = Properties.Resources.DrivingTest;

            lblFees.Text = TestType.Fees.ToString();
            lblID.Text = AppID.ToString();
            lblTrail.Text = Trails.ToString();
            lblReFees.Text = Retake.ToString();
            lblTfess.Text = (TestType.Fees + Retake).ToString();
        }
        private TestAppointment GetAppointment()
        {
            return new TestAppointment
            {
                TestAppointmentID = AppointmentID,
                TestTypeID = TestType.ID,
                LocalDrivingLicenseApplicationID = AppID,
                AppointmentDate = dateTimePicker.Value,
                PaidFees = Convert.ToDecimal(lblTfess.Text),
                CreatedByUserID = GlobalSettings.CurrentUser.UserId,
                TestResult = TestsResult.InProgress
            };
        }
    }
}
