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

        int _personID;
        LocalLicenseApplications _localApp = new LocalLicenseApplications();


        public LocalLicenseApplication()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToString();
            loadClasses();

        }

        public void loadClasses()
        {
            cbClass.DataSource = DrivinglicenseClassesBuisness.GetAllClasses();

            
            cbClass.DisplayMember = "ClassName";
            cbClass.SelectedIndex = 2;
            cbClass.ValueMember = "LicenseClassID";
        }
        public void SetAddMode()
        {
            _currentMode = FormMode.Add;
            this.personControl1.SetViewMode(null);
            SetControlsEnabled(true);
            //lblFees.Text = _type.Fees.ToString();
            lblStatus.Text = ApplicationStatus.New.ToString();
            lblUser.Text = GlobalSettings.CurrentUser.UserName;

        }
        public void SetUpdateMode(int localId)
        {
            _currentMode = FormMode.Update;
            _localApp = LocalLicenseApplicationBusiness.GetLocalApplication(localId);
            SetApplication(_localApp);
            SetControlsEnabled(true);
            panelFind.Visible = false;

        }

        public void SetViewMode(int localId)
        {
            _currentMode = FormMode.View;
            _localApp = LocalLicenseApplicationBusiness.GetLocalApplication(localId);
            SetApplication(_localApp);
            SetControlsEnabled(false);
        }

        public void GetApplication()
        {
            _localApp.person.PersonID = _personID;
            _localApp.Date = DateTime.Now;
            _localApp.LastStatusDate = DateTime.Now;
            _localApp.Type.ID = 1;
            _localApp.Status = (ApplicationStatus)1;
            _localApp.CreatedByUser.UserId = GlobalSettings.CurrentUser.UserId;
            _localApp.PaidFees = Convert.ToDecimal(lblFees.Text);
            _localApp.Class.ID = Convert.ToInt32(cbClass.SelectedValue);
            
        }
        public void SetApplication(LocalLicenseApplications app)
        {
            this.personControl1.SetViewMode(app.person.PersonID);
            this.lblId.Text = app.ID.ToString();
            this.lblDate.Text = app.Date.ToString();
            this.lblFees.Text = app.PaidFees.ToString();
            cbClass.SelectedValue = app.Class.ID;
            this.lblStatus.Text = app.Status.ToString();
            this.lblUser.Text = app.CreatedByUser.UserName;

        }
        private void SetControlsEnabled(bool enabled)
        {
            cbClass.Enabled = enabled;
            btnSave.Visible = enabled;
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
            if (_currentMode == FormMode.Add){ 
                if (!LocalLicenseApplicationBusiness.IsPersonHaveApp(_personID, Convert.ToInt32(cbClass.SelectedValue)))
                {
                    GetApplication();
                    int id = LocalLicenseApplicationBusiness.AddApp(_localApp);
                    if (id > 0)
                    {
                        MessageBox.Show("Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.lblId.Text = id.ToString();
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
            else
            {
                GetApplication();
                if (LocalLicenseApplicationBusiness.UpdateApp(_localApp))
                {
                    MessageBox.Show("Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
