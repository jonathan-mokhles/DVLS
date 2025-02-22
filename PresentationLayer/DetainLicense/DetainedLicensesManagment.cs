using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace DVLD
{
    public partial class DetainedLicensesManagment : Form
    {
        DetainedLicensesBusiness License = new DetainedLicensesBusiness();
        public DetainedLicensesManagment()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = License.GetAll() ;
        }

     }
}
