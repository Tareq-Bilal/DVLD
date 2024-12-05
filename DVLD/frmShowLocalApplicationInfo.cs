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
    public partial class frmShowLocalApplicationInfo : Form
    {
        public frmShowLocalApplicationInfo(int LocalDrivingLicenseApplicationID)
        {

            InitializeComponent();
            uC_LocalDrivingLicenseApploicationInfo1.Set(LocalDrivingLicenseApplicationID);

        }

        private void uC_LocalDrivingLicenseApploicationInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
