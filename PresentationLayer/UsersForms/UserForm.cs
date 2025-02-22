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
    public partial class UserForm : Form
    {
        private FormMode _mode;
        private int _UserId;
        public UserForm()
        {
            InitializeComponent();

        }
        public void SetMode(FormMode mode, int personId = -1)
        {
            _mode = mode;
            _UserId = personId;

            switch (mode)
            {
                case FormMode.View:
                    this.title.Text = "User Details";
                    this.userControl1.SetViewMode(personId);
                    break;
                case FormMode.Add:
                    this.title.Text = "Add New User";
                    this.userControl1.SetAddMode();
                    break;
                case FormMode.Update:
                    this.title.Text = "Update User";
                    this.userControl1.SetUpdateMode(personId);
                    break;
            }
        }


    }
}
