using PeopleBusinessLayer;
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
    public partial class frmAddUpdateUser : Form
    {
        clsUser CurrentUser = new clsUser();

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            tpAddUpdateUser.Selecting += new TabControlCancelEventHandler(tabPageLoginInfo_Enter);

            if (UserID != -1)
            {
                CurrentUser = clsUser.Find(UserID);
                uC_PersonInfoWithFilter1.IsUpdateMode = true;
                UC_PersonInfoWithFilter.clsPersonID.PersonID = CurrentUser.PersonID;
                CurrentUser.Mode = clsUser.enMode.Update;
            }



            else
                CurrentUser.Mode = clsUser.enMode.AddNew;

       }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            if(CurrentUser.Mode == clsUser.enMode.Update)
            {
                lblTitle.Text = "Update User";
                uC_PersonInfoWithFilter1.IsUpdateMode = true;
                clsPersonSelected.IsPersonSelected = true;
                tbUserName.Text = CurrentUser.UserName;
                tbPassword.Text = CurrentUser.Password;
                tbConfirmPassword.Text = CurrentUser.Password;
                lblUserID.Text = CurrentUser.UserID.ToString();
                chkIsActive.Checked = CurrentUser.IsActive;
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsPersonSelected.IsPersonSelected)
            {
                if (!clsUser.IsUserExistByPersonID(UC_PersonInfoWithFilter.clsPersonID.PersonID))
                {

                   clsPersonSelected.PersonID = UC_PersonInfoWithFilter.clsPersonID.PersonID;
                    tpAddUpdateUser.SelectedIndex++;
                    btnSave.Enabled = true;
                }

                else if(clsUser.IsUserExistByPersonID(UC_PersonInfoWithFilter.clsPersonID.PersonID) && (CurrentUser.Mode == clsUser.enMode.Update))
                {
                    tpAddUpdateUser.SelectedIndex++;
                    btnSave.Enabled = true;
                }

                else
                {
                    MessageBox.Show("Selected Person has already a user , choose another one !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsPersonSelected.IsPersonSelected = false;
                }

            }


            else
                MessageBox.Show("Please Select A Person", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tabPageLoginInfo_Enter(object sender, TabControlCancelEventArgs e)
        {
            if (!clsPersonSelected.IsPersonSelected)
                {
                    e.Cancel = true;  // Cancel the selection
                }

        }

        bool _IsThereEmptyFields()
        {

            return (string.IsNullOrEmpty(tbUserName.Text) && string.IsNullOrEmpty(tbPassword.Text) && string.IsNullOrEmpty(tbConfirmPassword.Text));

        }

        void _SetUesrInfo()
        {
            if(CurrentUser.Mode == clsUser.enMode.AddNew)
            {
                CurrentUser.PersonID = clsPersonSelected.PersonID;
                CurrentUser.UserName = tbUserName.Text;
                CurrentUser.Password = tbPassword.Text;
                CurrentUser.IsActive = chkIsActive.Checked;
                CurrentUser.Mode = clsUser.enMode.AddNew;
            }

            else
            {
                CurrentUser.UserName = tbUserName.Text;
                CurrentUser.Password = tbPassword.Text;
                CurrentUser.IsActive = chkIsActive.Checked;
                CurrentUser.Mode = clsUser.enMode.Update;

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsThereEmptyFields())
            {
             
               _SetUesrInfo();
               
               if (CurrentUser.Save())
               {
                    MessageBox.Show("Data Saved Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblUserID.Text = CurrentUser.UserID.ToString();
               }

                else
                   MessageBox.Show("Data Saved Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            else
                MessageBox.Show("Fill All Fields !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
         
            if(clsUser.IsUserExist(tbUserName.Text.Trim()))
            {
                e.Cancel = true;
                tbUserName.Select(0, tbUserName.Text.Length);
                epuserNameCheck.SetError(tbUserName, "User Name Is Already Exist !");

            }
        }

        private void tbUserName_Validated(object sender, EventArgs e)
        {
            epuserNameCheck.SetError(tbUserName, "");
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbConfirmPassword.Text))
                epPasswordMatchingCheck.SetError(tbConfirmPassword, "");

            if (tbConfirmPassword.Text != tbPassword.Text)
            {
                e.Cancel = true;
                tbConfirmPassword.Select(0, tbConfirmPassword.Text.Length);
                epPasswordMatchingCheck.SetError(tbConfirmPassword, "Passwords don't match. Please try again.");
            }

        }

        private void tbConfirmPassword_Validated(object sender, EventArgs e)
        {
                epPasswordMatchingCheck.SetError(tbConfirmPassword, "");
        }


    }
}
