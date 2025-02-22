using System;
using System.Windows.Forms;
using DVLD.DetainLicense;
using Entity;

namespace DVLD
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            numCountriesAsync(100,this.lblDrivers);
            numCountriesAsync(100,this.lblicense);
            numCountriesAsync(1000,this.lblilicense);

        }

        private void numCountriesAsync(int n,Label label)
        {
            int currentNumber = 0; // Start counting from 0
            int step = 10;          // Increment step
            Timer timer = new Timer(); 

            // Set the timer interval (e.g., 50 milliseconds for smooth animation)
            timer.Interval = 50;

            timer.Tick += (sender, e) =>
            {
                currentNumber += step;

                if (currentNumber >= n)
                {
                    currentNumber = n; 
                    timer.Stop();
                }

                label.Text = currentNumber.ToString();
            };

            timer.Start();
        }

        private void userMangmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMangment userMangment = new UserMangment();
            userMangment.ShowDialog();
           
        }

        private void peopleMangmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           PeopleMangment form = new PeopleMangment();
            form.ShowDialog();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.SetMode(FormMode.View, GlobalSettings.CurrentUserID);
            form.ShowDialog();
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.SetMode(FormMode.Update, GlobalSettings.CurrentUserID);
            form.ShowDialog();

        }

        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrivingApplicationTypesForm _DrivingApplicationTypes = new DrivingApplicationTypesForm();
            _DrivingApplicationTypes.ShowDialog();
        }

        private void licenseTestsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrivingApplicationTestsForm _tests = new DrivingApplicationTestsForm();
            _tests.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationLicenseForm form = new ApplicationLicenseForm();
            form.SetMode(FormMode.Add);
            form.ShowDialog();
        }

        private void localLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LocalLicenseApplicationManagment form = new LocalLicenseApplicationManagment();
            form.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplication form = new InternationalLicenseApplication();
            form.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InternationalLicenseMangmentcs form = new InternationalLicenseMangmentcs();
            form.ShowDialog();
        }

        private void renewLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLicense form = new RenewLicense();
            form.ShowDialog();
        }

        private void replacementLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementLicense form = new ReplacementLicense();
            form.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicenseForm form = new DetainLicenseForm();
            form.ShowDialog();
        }

        private void relaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseLicenseForm form = new ReleaseLicenseForm();
            form.ShowDialog();
        }

        private void manageDetainApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainedLicensesManagment form = new DetainedLicensesManagment();
            form.ShowDialog();
        }
    }
}
