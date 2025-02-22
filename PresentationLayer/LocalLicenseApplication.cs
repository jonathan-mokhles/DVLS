using BusinessLayer;
using Entity;
using System;
using System.Windows.Forms;
using System.Data;

namespace DVLD
{
    public partial class LocalLicenseApplication : UserControl
    {
        private FormMode _currentMode;
        DataTable _application;
        LocalLicenseApplicationBusiness app = new LocalLicenseApplicationBusiness();
        int _personID;

        public LocalLicenseApplication()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToString();
            lblUser.Text = GlobalSettings.CurrentUserID.ToString();
            loadClasses();

            ApplicationTypesBuisness type = new ApplicationTypesBuisness();
            _application = type.GetAllTypes();
        }

        public void loadClasses()
        {
            DrivinglicenseClassesBuisness types = new DrivinglicenseClassesBuisness();
            cbClass.DataSource = types.GetAllClasses();

            
            cbClass.DisplayMember = "ClassName";
            cbClass.SelectedIndex = 2;
            cbClass.ValueMember = "LicenseClassID";
        }

        public void SetAddMode()
        {
            _currentMode = FormMode.Add;
            this.personControl1.SetViewMode(null);
            SetControlsEnabled(true);
            btnSave.Visible = true;
            lblFees.Text = _application.Rows[0].Field<decimal>(2).ToString();
            lblStatus.Text = ApplicationStatus.New.ToString();
        }

        public void SetViewMode(int userId)
        {
            _currentMode = FormMode.View;
            SetApplication(app.GetLocalApplication(userId));
            SetControlsEnabled(false);
            panelFind.Visible = false;
        }

        public LocalLicenseApplications GetApplication()
        {
            return new LocalLicenseApplications
            {
                Application = new Applications
                {
                    PersonID = _personID,
                    Date = DateTime.Now,
                    LastStatusDate = DateTime.Now,
                    TypeID = 1,
                    Status = (ApplicationStatus)1,
                    CreatedByUserId = GlobalSettings.CurrentUserID,
                    PaidFees = Convert.ToDecimal(lblFees.Text)
                },
                classID = Convert.ToInt32(cbClass.SelectedValue.ToString())
            };               
        }
        public void SetApplication(LocalLicenseApplications app)
        {
            this.personControl1.SetViewMode(app.Application.PersonID);
            this.lblId.Text = app.Application.ID.ToString();
            this.lblDate.Text = app.Application.Date.ToString();
            this.lblFees.Text = app.Application.PaidFees.ToString();
            cbClass.SelectedValue = app.classID;
            this.lblStatus.Text = app.Application.Status.ToString();

        }
        public void SetUpdateMode(int userId)
        {
            _currentMode = FormMode.Update;
            SetControlsEnabled(true);
            panelFind.Visible = false;
        }
        private void SetControlsEnabled(bool enabled)
        {
            cbClass.Enabled = enabled;
            panelFind.Enabled = enabled;
        }

        private void tap_Selecting(object sender, TabControlCancelEventArgs e)
        {
            People _person = personControl1.GetPersonFromForm();
            if (_person.NationalNo == "???")
            {
                errorProvider1.SetError(this.tbNationalNo, "Please enter a valid National No.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(this.tbNationalNo, string.Empty);
            }
            _personID = _person.PersonID;

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.personControl1.SetViewMode(tbNationalNo.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!app.IsPersonHaveApp(_personID, Convert.ToInt32(cbClass.SelectedValue.ToString())))
            {
                if (app.AddApp(GetApplication())>0)
                {
                    MessageBox.Show("Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("this person already have active application for the same license class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //lblFees.Text = licenseClasses.Rows[cbClass.SelectedIndex].Field<decimal>(5).ToString();

    }
}
