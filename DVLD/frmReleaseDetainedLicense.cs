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
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense(int DetainID = -1)
        {
            InitializeComponent();

            uC_ReleaseDetainedLicenses1.SetDetainID(DetainID);

        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}