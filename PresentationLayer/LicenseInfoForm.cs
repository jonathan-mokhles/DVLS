﻿using System;
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
    public partial class LicenseInfoForm : Form
    {
        public LicenseInfoForm(int id)
        {
            InitializeComponent();
            this.licenseInfoControlcs1.LoadForm(id);

        }
    }
}
