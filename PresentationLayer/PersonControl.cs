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

namespace DVLD
{
    public partial class PersonControl : System.Windows.Forms.UserControl
    {
        private PeopleBusiness _peopleBusiness = new PeopleBusiness();

        public PersonControl()
        {
            InitializeComponent();
            LoadCountries();
            LoadDate();
        }

        private void LoadCountries()
        {
            var countries = new CountriesBuisness().GetAllCountries();
            ComboxContries.DataSource = countries;
            ComboxContries.DisplayMember = "CountryName";
            ComboxContries.ValueMember = "CountryID";
            ComboxContries.SelectedValue = 51;
        }

        private void LoadDate()
        {
            dtDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
        }

        public int SetViewMode(int personId)
        {
            People person = _peopleBusiness.GetPerson(personId);
            LoadPerson(person);
            SetControlsEnabled(false);
            btnUpdate.Visible = false;
            btnAdd.Visible = false;
            return person.PersonID;
        }
        public int SetViewMode(string personNo)
        {
            People person;
            if (personNo != null)
                person = _peopleBusiness.GetPerson(personNo);
            else
                person = new People();
           

            LoadPerson(person);
            SetControlsEnabled(false);
            btnUpdate.Visible = false;
            btnAdd.Visible = false;

            return person.PersonID;

        }

        public void SetAddMode()
        {
            ClearForm();
            SetControlsEnabled(true);
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
        }


        public void SetUpdateMode(int personId)
        {
            LoadPerson(_peopleBusiness.GetPerson(personId));
            SetControlsEnabled(true);
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
        }

        private void LoadPerson(People person)
        {
            if (person != null)
            {
                lblID.Text = person.PersonID.ToString();
                tbfirstName.Text = person.FirstName;
                tblastName.Text = person.LastName;
                tbAddress.Text = person.Address;
                tbEmail.Text = person.Email;
                TBNational.Text = person.NationalNo;
                tbPhone.Text = person.Phone;
                ComboxContries.Text = person.Nationality;
                dtDateOfBirth.Value = person.DateOfBirth;
                RBMale.Checked = person.Gender == 'M';
                RBFemale.Checked = person.Gender == 'F';
                loadPic(person.ImagePath);
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
            ComboxContries.SelectedIndex = 51;
            dtDateOfBirth.Value = DateTime.Today.AddYears(-18);
            RBMale.Checked = true;
            loadPic(null);
        }

        public void SetControlsEnabled(bool enabled)
        {
            tbfirstName.Enabled = enabled;
            tblastName.Enabled = enabled;
            tbAddress.Enabled = enabled;
            tbEmail.Enabled = enabled;
            TBNational.Enabled = enabled;
            tbPhone.Enabled = enabled;
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
                Nationality = ComboxContries.Text,
                DateOfBirth = dtDateOfBirth.Value,
                Gender = RBMale.Checked ? 'M' : 'F',
                ImagePath = pictureBox1.ImageLocation
            };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var person = GetPersonFromForm();
            if (_peopleBusiness.UpdatePerson(person)>0)
            {
                MessageBox.Show("Person updated successfully.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var person = GetPersonFromForm();
            if (_peopleBusiness.AddPerson(person) > 0)
            {
                MessageBox.Show("Person added successfully.");
            }
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
            else if (!_peopleBusiness.isUniqueNum(textBox.Text))
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
                string _imageFolderPath = "C:\\Users\\Mofid\\Desktop\\coding\\C#\\DVLS\\images\\";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string newImagePath = Path.Combine(_imageFolderPath, Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath));

                    // Delete the old image if it exists
                    if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
                    {
                        File.Delete(pictureBox1.ImageLocation);
                    }

                    // copy the new image to the project folder
                    File.Copy(selectedImagePath, newImagePath);

                    pictureBox1.ImageLocation = newImagePath;
                }
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
    }

}
