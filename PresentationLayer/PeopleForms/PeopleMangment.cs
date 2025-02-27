using BusinessLayer;
using System;
using System.Windows.Forms;
using Entity;

namespace DVLD
{
    public partial class PeopleMangment : Form
    {
        public PeopleMangment()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = PeopleBusiness.GetAllPeople();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var form = new PeopleForm();
            form.SetMode(FormMode.Add);
            form.ShowDialog();
            LoadData();
        }

        private void ViewPerson_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int personId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PersonID"].Value);
                var form = new PeopleForm();
                form.SetMode(FormMode.View, personId);
                form.ShowDialog();
            }
        }

        private void UpdatePerson_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int personId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PersonID"].Value);
                var form = new PeopleForm();
                form.SetMode(FormMode.Update, personId);
                form.ShowDialog();
                LoadData();
            }
        }

        private void DeletePerson_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int personId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PersonID"].Value);
                var result = MessageBox.Show("Are you sure you want to delete this person?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    PeopleBusiness.DeletePerson(personId);
                    LoadData();
                }
            }
        }
    }
}
