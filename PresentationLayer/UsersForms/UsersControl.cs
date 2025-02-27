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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class UsersControl : System.Windows.Forms.UserControl
    {
        private People _person;
        private FormMode _currentMode;
        private int _currentUserId;

        public UsersControl()
        {
            InitializeComponent();
        }

        public void SetAddMode()
        {
           _currentMode = FormMode.Add;
            ClearForm();
            this.personControl1.SetViewMode(null);
            SetControlsEnabled(true);
            btnSave.Visible = true;
        }

        public void SetViewMode(int userId)
        {
            _currentMode = FormMode.View;
            _currentUserId = userId;
            LoadUser(userId);
            SetControlsEnabled(false);
            panelFind.Visible = false;


        }

        public void SetUpdateMode(int userId)
        {
            _currentMode = FormMode.Update;
            _currentUserId = userId;
            LoadUser(userId);
            SetControlsEnabled(true);
            panelFind.Visible = false;
            btnUpdate.Visible = true;
        }



        private void LoadUser(int userId)
        {
            var user = UserBuisness.GetUser(userId);
            if (user != null)
            {
                lblUserId.Text = user.UserId.ToString();
                TBUserName.Text = user.UserName;
                tbpassword.Text = user.Password;
                tbConfirm.Text = user.Password; 
                chbIsActive.Checked = user.IsActive;
                personControl1.SetViewMode(user.person.NationalNo); 
            }
        }

        private void ClearForm()
        {
            TBUserName.Text = string.Empty;
            tbpassword.Text = string.Empty;
            tbConfirm.Text = string.Empty;
            chbIsActive.Checked = false;
            personControl1.ClearForm();
        }

        private void SetControlsEnabled(bool enabled)
        {
            TBUserName.Enabled = enabled;
            tbpassword.Enabled = enabled;
            tbConfirm.Enabled = enabled;
            chbIsActive.Enabled = enabled;
            panelFind.Enabled = enabled;
        }


        private void tb_Validating(object sender, CancelEventArgs e)
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

        private void tbConfirm_Validating(object sender, CancelEventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;
            if (string.IsNullOrWhiteSpace(textBox?.Text))
            {
                errorProvider1.SetError(textBox, "This field is required.");
                e.Cancel = true;
            }
            else if (textBox.Text != tbpassword.Text)
            {
                errorProvider1.SetError(textBox, "The password does not match.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }

        private User GetUserFromForm()
        {
            _person = personControl1.GetPersonFromForm();
            User user = new User(_person)
            {
                UserName = TBUserName.Text,
                Password = tbpassword.Text,
                IsActive = chbIsActive.Checked,
                Role = 1 
            };
            return user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ID = UserBuisness.AddUser(GetUserFromForm());
            if ( ID > 0)
            {
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lblUserId.Text = ID.ToString();
            }
            else
            {
                MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.personControl1.SetViewMode(tbNationalNo.Text);
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
                if (_currentMode == FormMode.Update)
                {
                    var user = GetUserFromForm();
                    user.UserId = _currentUserId; 

                    if (UserBuisness.UpdateUser(user) > 0)
                    {
                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
        }

        private void tap_Selecting(object sender, TabControlCancelEventArgs e)
        {
            _person = personControl1.GetPersonFromForm();
            if (_person.NationalNo == "???")
            {
                errorProvider1.SetError(this.tbNationalNo, "Please enter a valid National No.");
                e.Cancel = true;
            }
            else if (_currentMode == FormMode.Add && UserBuisness.isUserExist(_person.NationalNo))
            {
                errorProvider1.SetError(this.tbNationalNo, "This person is already a user.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(this.tbNationalNo, string.Empty);
            }

        }
    }
}
