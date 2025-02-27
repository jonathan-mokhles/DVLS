using System;
using BusinessLayer;
using System.Windows.Forms;
using System.Data;
using Entity;

namespace DVLD
{
    public partial class UserMangment : Form
    {
        public UserMangment()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = UserBuisness.GetAllUsers();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.SetMode(FormMode.Add);
            form.ShowDialog();
            LoadData();
        }

        private void ViewUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);
                UserForm form = new UserForm();
                form.SetMode(FormMode.View, userId);
                form.ShowDialog();
                LoadData();
            }
        }

        private void UpdateUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);
                UserForm form = new UserForm();
                form.SetMode(FormMode.Update, userId);
                form.ShowDialog();
                LoadData();
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int personId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PersonID"].Value);
                var result = MessageBox.Show("Are you sure you want to delete this person?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    UserBuisness.DeleteUser(personId);
                    LoadData();
                }
            }
        }
    }
    
}
