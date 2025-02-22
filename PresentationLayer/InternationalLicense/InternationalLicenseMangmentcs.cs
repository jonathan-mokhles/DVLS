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
    public partial class InternationalLicenseMangmentcs : Form
    {
        InternationalLicenseBusiness _licenseBusines = new InternationalLicenseBusiness();
        public InternationalLicenseMangmentcs()
        {
            InitializeComponent();
            dataGridView1.DataSource = _licenseBusines.GetLAllLicense();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                InternationalLicenseInfo form = new InternationalLicenseInfo(id);
                form.ShowDialog();
            }
        }
    }
}
