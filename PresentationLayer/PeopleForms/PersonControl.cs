using Entity;
using System;
using System.Data;
using BusinessLayer;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.IO;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace DVLD
{
    public partial class PersonControl : System.Windows.Forms.UserControl
    {
        People _person = new People();
        FormMode _mode;
        public PersonControl()
        {
            InitializeComponent();
            LoadCountries();
            _LoadDate();
        }

        private void LoadCountries()
        {
            var countries = new CountriesBuisness().GetAllCountries();
            ComboxContries.DataSource = countries;
            ComboxContries.DisplayMember = "CountryName";
            ComboxContries.ValueMember = "CountryID";
            ComboxContries.SelectedValue = 51;
        }

        private void _LoadDate()
        {
            dtDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
        }

        public int SetViewMode(int personId)
        {
            _person = PeopleBusiness.GetPerson(personId);
            LoadPerson();
            SetControlsEnabled(false);
            btnSave.Visible = false;
            _mode = FormMode.View;
            return personId;
        }
        public void SetViewMode(string personNo)
        {
            if (personNo != null)
                _person = PeopleBusiness.GetPerson(personNo);


            if (personNo != null)
                LoadPerson();
            
            SetControlsEnabled(false);
            btnSave.Visible = false;
            _mode = FormMode.View;

        }

        public void SetAddMode()
        {
            ClearForm();
            SetControlsEnabled(true);
            _mode = FormMode.Add;
        }

        public void SetUpdateMode(int personId)
        {
            _person = PeopleBusiness.GetPerson(personId);
            LoadPerson();
            SetControlsEnabled(true);
            _mode = FormMode.Update;
        }

        private void LoadPerson()
        {
            
            if (_person != null)
            {
                lblID.Text = _person.PersonID.ToString();
                tbfirstName.Text = _person.FirstName;
                tblastName.Text = _person.LastName;
                tbAddress.Text = _person.Address;
                tbEmail.Text = _person.Email;
                TBNational.Text = _person.NationalNo;
                tbPhone.Text = _person.Phone;
                ComboxContries.SelectedValue = _person.NationalityID;
                dtDateOfBirth.Value = _person.DateOfBirth;
                RBMale.Checked = _person.Gender == 'M';
                RBFemale.Checked = _person.Gender == 'F';
                loadPic(_person.ImagePath);
            }
        }

        public void ClearForm()
        {
            lblID.Text = string.Empty;
            tbfirstName.Text = string.Empty;
            tblastName.Text = string.Empty;
            tbAddress.Text = string.Empty;
            tbEmail.Text = string.Empty;
            TBNational.Text = string.Empty;
            tbPhone.Text = string.Empty;
            ComboxContries.SelectedValue = 51;
            dtDateOfBirth.Value = DateTime.Today.AddYears(-18);
            RBMale.Checked = true;
            loadPic(null);
        }

        public void SetControlsEnabled(bool enabled)
        {
            tbfirstName.ReadOnly = !enabled;
            tblastName.ReadOnly = !enabled;
            tbAddress.ReadOnly = !enabled;
            tbEmail.ReadOnly = !enabled;
            TBNational.Enabled = enabled;
            tbPhone.ReadOnly = !enabled;
            ComboxContries.Enabled = enabled;
            dtDateOfBirth.Enabled = enabled;
            RBMale.Enabled = enabled;
            RBFemale.Enabled = enabled;
            lblDelete.Enabled = enabled;
            lblPicture.Enabled = enabled;

        }

        private void loadPic(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                pictureBox1.Image = RBMale.Checked ? Properties.Resources.male : Properties.Resources.female;
            }
            else
            {
                pictureBox1.ImageLocation = path;
            }
        }

        public People GetPersonFromForm()
        {
            return new People
            {
                PersonID = string.IsNullOrEmpty(lblID.Text) ? 0 : int.Parse(lblID.Text),
                FirstName = tbfirstName.Text,
                LastName = tblastName.Text,
                Address = tbAddress.Text,
                Email = tbEmail.Text,
                NationalNo = TBNational.Text,
                Phone = tbPhone.Text,
                NationalityID = (int)ComboxContries.SelectedValue,
                DateOfBirth = dtDateOfBirth.Value,
                Gender = RBMale.Checked ? 'M' : 'F',
                ImagePath = _person.ImagePath
            };
        }

        private void ValidateRequiredField(object sender, CancelEventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;
            if (string.IsNullOrWhiteSpace(textBox?.Text))
            {
                errorProvider1.SetError(textBox, "This field is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void ValidateNationalNo(object sender, CancelEventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;
            if (string.IsNullOrWhiteSpace(textBox?.Text))
            {
                errorProvider1.SetError(textBox, "This field is required.");
                e.Cancel = true;
            }
            else if (!PeopleBusiness.isUniqueNum(textBox.Text))
            {
                errorProvider1.SetError(textBox, "National number must be unique.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            loadPic(pictureBox1.ImageLocation);
        }
        private void lblPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an Image";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    pictureBox1.ImageLocation = selectedImagePath;
                }
            }
        }

        void SavePicture()
        {
            string _imageFolderPath = "C:\\Users\\Mofid\\Desktop\\coding\\C#\\DVLS\\images\\";

            string newImagePath = Path.Combine(_imageFolderPath, Guid.NewGuid().ToString() + Path.GetExtension(pictureBox1.ImageLocation));

            if (string.IsNullOrEmpty(_person.ImagePath) && !string.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                File.Copy(pictureBox1.ImageLocation, newImagePath);
                _person.ImagePath = newImagePath;
                MessageBox.Show("1");
            }
            else if(!string.IsNullOrEmpty(_person.ImagePath) && string.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                MessageBox.Show($"Attempting to delete: {_person.ImagePath}\nExists: {File.Exists(_person.ImagePath)}");
                File.Delete(_person.ImagePath);
                _person.ImagePath = null;

            }
            else if (!string.IsNullOrEmpty(_person.ImagePath + pictureBox1.ImageLocation) && pictureBox1.ImageLocation != _person.ImagePath)
            {
                MessageBox.Show($"Attempting to delete: {_person.ImagePath}\nExists: {File.Exists(_person.ImagePath)}");
                File.Copy(pictureBox1.ImageLocation, newImagePath);
                File.Delete(_person.ImagePath);
                _person.ImagePath = newImagePath;

            }

        }

        private void lblDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                // Delete the image file
                File.Delete(pictureBox1.ImageLocation);

                // Clear the PictureBox and reset to default image
                pictureBox1.ImageLocation = null;
                loadPic(null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                SavePicture();
                if (_mode == FormMode.Update)
                {
                    People person = GetPersonFromForm();
                    if (PeopleBusiness.UpdatePerson(person) > 0)
                    {
                        MessageBox.Show("Person updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    People person = GetPersonFromForm();
                    int id = PeopleBusiness.AddPerson(person);
                    if (id > 0)
                    {
                        MessageBox.Show("Person updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.lblID.Text = id.ToString();
                    }
                }
            }
        }
    }

}
