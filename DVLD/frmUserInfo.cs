using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusinessLayer;

namespace DVLD
{
    public partial class frmUserInfo : Form
    {
        int _UserID;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;


        }
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            uC_PersonInfo1.CurrentPersonID = clsUser.GetPersonIDByUserID(_UserID); ;
            uC_PersonInfo1.LoadPersonInfo();
            uC_LoginInfo1.UserID = _UserID;
            uC_LoginInfo1.LoadLoginInfo();
        }
    }
}
