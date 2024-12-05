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
    public partial class frmInternationalDriverLicenseInfo : Form
    {
        public frmInternationalDriverLicenseInfo(int IntLicenseID)
        {
            InitializeComponent();

            uC_DriverInternationalLicenseInfo1.SetInternationalDriverLicenseInfo(IntLicenseID);

        }
    }
}
