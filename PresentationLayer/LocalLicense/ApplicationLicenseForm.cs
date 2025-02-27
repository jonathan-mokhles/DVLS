using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ApplicationLicenseForm : Form
    {
        private FormMode _mode;
        public ApplicationLicenseForm()
        {
            InitializeComponent();
        }
        public void SetMode(FormMode mode, int appID = -1)
        {
            _mode = mode;

            switch (mode)
            {
                case FormMode.View:
                    this.title.Text = "local Driving license application";
                    this.localLicenseApplication1.SetViewMode(appID);
                    break;
                case FormMode.Add:
                    this.title.Text = "New local Driving license application";
                    this.localLicenseApplication1.SetAddMode();
                    break;
                case FormMode.Update:
                    this.title.Text = "Update local Driving license application";
                    this.localLicenseApplication1.SetUpdateMode(appID);
                    break;
            }
        }
    }
}
