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
    public partial class PeopleForm : Form
    {
        private FormMode _mode;
        private int _personId;

        public PeopleForm()
        {
            InitializeComponent();
        }

        public void SetMode(FormMode mode, int personId = -1)
        {
            _mode = mode;
            _personId = personId;

            switch (mode)
            {
                case FormMode.View:
                    this.title.Text = "Person Details";
                    this.personControl1.SetViewMode(personId);
                    break;
                case FormMode.Add:
                    this.title.Text = "Add New Person";
                    this.personControl1.SetAddMode();
                    break;
                case FormMode.Update:
                    this.title.Text = "Update Person";
                    this.personControl1.SetUpdateMode(personId);
                    break;
            }
        }
    }
}
