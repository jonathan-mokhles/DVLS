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
    public partial class LocalLicenseApplicationInfo : UserControl
    {
        public LocalLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void SetApp(LocalLicenseApplications app) { 
            this.applicationControl1.SetApplication(app.Application);
            this.lblClass.Text = app.className;
            this.lblId.Text = app.LocalID.ToString();
        }


    }
}
