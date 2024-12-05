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
    public partial class frmPersonInfo : Form
    {
        int _CurrentPersonID = 0;
        public frmPersonInfo(int PeronID)
        {
            InitializeComponent();
            _CurrentPersonID = PeronID;


        }
        private void frmPersonInfo_Load(object sender, EventArgs e)
        {

            uC_PersonInfo1.CurrentPersonID = _CurrentPersonID;
            uC_PersonInfo1.LoadPersonInfo();
        }

        private void uC_PersonInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
