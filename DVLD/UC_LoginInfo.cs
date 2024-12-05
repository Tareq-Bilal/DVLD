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
    public partial class UC_LoginInfo : UserControl
    {
        clsUser User = new clsUser();
        public int UserID ; 
        public UC_LoginInfo()
        {
            InitializeComponent();
        }


        public void LoadLoginInfo()
        {
            User = clsUser.Find(UserID);
            lblUserID.Text   = User.UserID.ToString();
            lblUserName.Text = User.UserName.ToString();

            if (User.IsActive)
                lblIsActive.Text = "Yes";

            else
                lblIsActive.Text = "No";

        }

        private void UC_LoginInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
