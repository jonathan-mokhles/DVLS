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

        private void button1_Click(object sender, EventArgs e)
        {
            user = userBuisness.login(textBox1.Text,textBox2.Text);
            MessageBox.Show(user.Phone);
        }

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
