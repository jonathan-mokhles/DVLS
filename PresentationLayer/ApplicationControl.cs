using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entity;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ApplicationControl : UserControl
    {
        public ApplicationControl()
        {
            InitializeComponent();
        }
        public void SetApplication(Applications app)
        {
            lblApplicat.Text = app.PersonName;
            lblId.Text = app.ID.ToString();
            lblDate.Text = app.Date.ToString();
            lblFees.Text = app.PaidFees.ToString();
            lblLastDate.Text = app.LastStatusDate.ToString();
            lblStatus.Text = app.Status.ToString();
            lblType.Text = app.TypeName;
            lblUser.Text = app.CreatedByUserName;
        }
    }
}
