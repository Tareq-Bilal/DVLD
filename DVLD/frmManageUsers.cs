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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        void _LoadUsers()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            dgvUsers.Columns[3].Visible = false;
            lblNumberOfRecords.Text = clsUser.GetNumberOfUsers().ToString();

        }

        private bool IsNumeric(string value)
        {
            double result;
            return double.TryParse(value, out result);
        }


        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cbIsActive.Visible = false;

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                tbSearch.Visible = false;
                cbIsActive.Visible = false;
                _LoadUsers();
            }

            else if (cbFilter.SelectedItem.ToString() == "Is Active")
            {
                // loaction : 
                tbSearch.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Location = new Point(309, 276);


            }

            else
            {
                tbSearch.Visible = true;
                cbIsActive.Visible = false;

            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SearchingInfo;

            if (cbIsActive.SelectedItem.ToString() == "Yes")
                SearchingInfo = "1";

            else if (cbIsActive.SelectedItem.ToString() == "No")
                SearchingInfo = "0";

            else
                SearchingInfo = "ALL";


            dgvUsers.DataSource = clsUser.GetUserByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchingInfo = tbSearch.Text.Trim();

            dgvUsers.DataSource = clsUser.GetUserByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((cbFilter.SelectedItem.ToString() == "User ID" || cbFilter.SelectedItem.ToString() == "Person ID") )
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // If it's not a control key or a digit, suppress the key press
                    e.Handled = true;
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser(-1);
            frmAddUpdateUser.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser(-1);
            frmAddUpdateUser.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are You Sure To Delete User [" + (int)dgvUsers.CurrentRow.Cells[0].Value + "] ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.Yes)
            {
                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Delete Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageUsers frmManageUsers = new frmManageUsers();
                    frmManageUsers.ShowDialog();
                }

                else
                    MessageBox.Show("User Delete Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                frmManageUsers frmManageUsers = new frmManageUsers();
                frmManageUsers.ShowDialog();
            }
    

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frmAddUpdateUser.ShowDialog();
        }

        private void ChangePasswordtoolStripitem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[1].Value);
            frmChangePassword.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnted Yet !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Not Implemnted Yet !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frmUserInfo.ShowDialog();   
        }
    }
}
