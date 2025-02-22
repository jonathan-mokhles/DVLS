using BusinessLayer;
using Entity;
using System.Windows.Forms;

namespace DVLD
{
    public partial class TakeTest : Form
    {
        TestAppointment testAppointment;
        TestAppointmentBusiness _appointmentBusiness = new TestAppointmentBusiness();
        int Trails;
        public TakeTest(int testID,int trails)
        {
            testAppointment = _appointmentBusiness.GetTestAppointmentByID(testID);
            int Trails = trails;
            InitializeComponent();
            SetForm();
        }
        private void SetForm()
        {
            if (testAppointment.TestTypeID == 1)
                pictureBox1.Image = Properties.Resources.VisionTest;

            else if (testAppointment.TestTypeID == 2)
                pictureBox1.Image = Properties.Resources.WrittenTest;

            else if (testAppointment.TestTypeID == 3)
                pictureBox1.Image = Properties.Resources.DrivingTest;

            lblID.Text = testAppointment.TestAppointmentID.ToString();
            lblDate.Text = testAppointment.AppointmentDate.ToString();
            lblTrail.Text = Trails.ToString();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            testAppointment.Notes = tbNotes.Text;
            testAppointment.TestResult = rbPass.Checked? TestsResult.Passed : TestsResult.Failed;
            _appointmentBusiness.UpdateTestAppointment(testAppointment);
            this.Close();
        }
    }
}
