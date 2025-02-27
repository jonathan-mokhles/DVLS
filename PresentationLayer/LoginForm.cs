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
                HomeForm form = new HomeForm();
                this.Hide();
                form.FormClosed += (s, args) => Application.Exit();
                form.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
