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
    public partial class LoginForm : Form
    {
        private HomeForm homeForm = null;
        public LoginForm()
        {
            InitializeComponent();
        }
        UserBuisness userBuisness = new UserBuisness();
        User user = new User();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            user = userBuisness.login(textBox1.Text, textBox2.Text);
            if (user == null)
            {
                MessageBox.Show("The Username or Password is Incorrect. Try again.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (!user.IsActive)
            {
                MessageBox.Show("this user is inactive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GlobalSettings.CurrentUser = user;
                if (homeForm == null || homeForm.IsDisposed)
                {
                    homeForm = new HomeForm();
                    homeForm.FormClosed += (s, args) => this.Close();
                }

                homeForm.Show(this);
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(homeForm != null)
                homeForm.Close();
            this.Close();

        }
    }
}
