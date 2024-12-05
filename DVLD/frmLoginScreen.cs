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
using System.IO;

namespace DVLD
{
    public partial class frmLoginScreen : Form
    {        
        string LoginDataFilePath = @"D:\TAREQ\Course 19 - Full Real Project\DVLD\bin\Debug\LoginData.txt";
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsUser.IsUserExist(txtUserName.Text.Trim()))
            {
                clsCurrentUser.CurrentUser = clsUser.Find(txtUserName.Text.Trim());

                if (clsCurrentUser.CurrentUser.UserName == txtUserName.Text.Trim() && clsCurrentUser.CurrentUser.Password == txtPassword.Text.Trim() && clsCurrentUser.CurrentUser.IsActive)
                {
                    clsLogin.IsValidLogin = true;
                    _ChangeRememberMeStatus(chkRememberMe.Checked);
                    this.Close();
                }

                else if (clsCurrentUser.CurrentUser.Password != txtPassword.Text.Trim())
                {
                    MessageBox.Show("Wrong Password !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (!clsCurrentUser.CurrentUser.IsActive)
                {
                    MessageBox.Show("User Is Not Active !, Please Contact With Your Admin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            else
            {
                MessageBox.Show("User Does Not Found ! , Please Try Again", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        public void AddToFile(string content)
        {
            using (StreamWriter sw = File.AppendText(LoginDataFilePath))
            {
                sw.WriteLine(content);
            }
        }

        public void DeleteAllFromFile()
        {
            if (File.Exists(LoginDataFilePath))
            {
                File.WriteAllText(LoginDataFilePath, string.Empty);
            }
            else
            {
                throw new FileNotFoundException("The specified file was not found.", LoginDataFilePath);
            }
        }

        public List<string> LoadAndSplitDataFromFile(char separator)
        {
            var resultList = new List<string>();

            if (File.Exists(LoginDataFilePath))
            {
                var lines = File.ReadAllLines(LoginDataFilePath);
                foreach (var line in lines)
                {
                    var splitParts = line.Split(separator);
                    resultList.AddRange(splitParts);
                }
            }
            else
            {
                throw new FileNotFoundException("The specified file was not found.", LoginDataFilePath);
            }

            return resultList;
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
           
            List<string> Info = LoadAndSplitDataFromFile('~');

            try
            {
                if (Info[2].ToString() == "1")
                {
                    txtUserName.Text = Info[0];
                    txtPassword.Text = Info[1];
                    chkRememberMe.Checked = true;
                }


            }
  
            catch(Exception ex)
            {
                ex.Source = "Error";
            }



        }

        private void _ChangeRememberMeStatus(bool Checked)
        {
            if (Checked)
            {
                DeleteAllFromFile();
                AddToFile(txtUserName.Text.Trim() + "~" + txtPassword.Text.Trim() + "~" + 1);

            }

            else
            {
                DeleteAllFromFile();

            }
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeRememberMeStatus(chkRememberMe.Checked);

        }

    }
}
