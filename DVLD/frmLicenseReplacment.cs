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
    public partial class frmLicenseReplacment : Form
    {
        public frmLicenseReplacment()
        {
            InitializeComponent();
            this.AcceptButton = null;  // Ensure no button closes the form automatically
            this.CancelButton = null;  // Prevent the form from closing automatically

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseReplacment_Load(object sender, EventArgs e)
        {

        }
    }
}
