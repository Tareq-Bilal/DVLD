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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class frmChangePassword : Form
    {
        int CurrentPersonID;
        clsUser CurrentUser = new clsUser();
        public frmChangePassword(int PersonID)
        {
            InitializeComponent();
            CurrentPersonID = PersonID;

            CurrentUser = clsUser.Find(clsUser.GetUserIDByPersonID(CurrentPersonID));

        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {


            if (string.IsNullOrEmpty(tbCurrentPassword.Text))
                epCurrentPasswordCheck.SetError(tbCurrentPassword, "");

           else if (tbCurrentPassword.Text != CurrentUser.Password)
            {
                e.Cancel = true;
                tbCurrentPassword.Select(0, tbCurrentPassword.Text.Length);
                epCurrentPasswordCheck.SetError(tbCurrentPassword, "Wrong Password !");

            }


        }

        private void tbCurrentPassword_Validated(object sender, EventArgs e)
        {
            epCurrentPasswordCheck.SetError(tbCurrentPassword, "");

        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {


            if (tbNewPassword.Text != tbConfirmPassword.Text)
            {
                e.Cancel = true;
                tbConfirmPassword.Select(0, tbCurrentPassword.Text.Length);
                epNewPasswordsMatching.SetError(tbConfirmPassword, "Password Does NOT Matching !");
            }



        }

        private void tbConfirmPassword_Validated(object sender, EventArgs e)
        {
            epNewPasswordsMatching.SetError(tbConfirmPassword, "");
        }

        private void frmChangePassword_Load_1(object sender, EventArgs e)
        {
            uC_PersonInfo1.CurrentPersonID = CurrentPersonID;
            uC_PersonInfo1.LoadPersonInfo();
            uC_LoginInfo1.UserID = clsUser.GetUserIDByPersonID(CurrentPersonID);
            uC_LoginInfo1.LoadLoginInfo();
        }

        bool _IsThereEmptyFields()
        {

            return (string.IsNullOrEmpty(tbCurrentPassword.Text) && string.IsNullOrEmpty(tbNewPassword.Text) && string.IsNullOrEmpty(tbConfirmPassword.Text));

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsThereEmptyFields())
            {
                CurrentUser.Password = tbNewPassword.Text;

                if (CurrentUser.Save())
                    MessageBox.Show("Data Saved Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("Please Fill All Fields!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }

        private void tbCurrentPassword_Leave(object sender, EventArgs e)
        {



        }
    }
}
