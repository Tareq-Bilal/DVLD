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
    public partial class MainForm : Form
    {
        private Timer timer;
        public MainForm()
        {
            InitializeComponent();

            timer = new Timer
            {
                Interval = 1000 // 1000 milliseconds = 1 second
            };
            timer.Tick += Timer_Tick;
            timer.Start();

    

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!clsLogin.IsValidLogin)
            {
                frmLoginScreen frmLoginScreen = new frmLoginScreen();
                frmLoginScreen.ShowDialog();

       
            }

            this.WindowState = FormWindowState.Maximized;
            lblDate.Text = DateTime.Now.ToShortDateString();


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople frmManagePeople = new frmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void PeopletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frmManagePeople = new frmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void cuurentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo(clsCurrentUser.CurrentUser.UserID);
            frmUserInfo.ShowDialog();

        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsCurrentUser.CurrentUser.PersonID);
            frmChangePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Application.Restart();
            this.Close();

        }

        private void ApplicationstoolStripMenu_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void UserstoolStripMenu_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void manageApplicatoinsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frmManageApplicationTypes = new frmManageApplicationTypes();
            frmManageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frmManageTestTypes = new frmManageTestTypes();
            frmManageTestTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicense frmAddUpdateLocalDrivingLicense = new frmAddUpdateLocalDrivingLicense();
            frmAddUpdateLocalDrivingLicense.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frmManageLocalDrivingLicenseApplications = new frmManageLocalDrivingLicenseApplications();
            frmManageLocalDrivingLicenseApplications.ShowDialog();
        }

        private void DriverstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frmManageDrivers = new frmManageDrivers();
            frmManageDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicense frmAddInternationalLicense = new frmAddInternationalLicense();
            frmAddInternationalLicense.ShowDialog();
        }

        private void internationalDrivingLicenseApplicatoinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenses frmManageInternationalLicenses = new frmManageInternationalLicenses();
            frmManageInternationalLicenses.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewDrivingLicense frmRenewDrivingLicense = new frmRenewDrivingLicense();
            frmRenewDrivingLicense.ShowDialog();
        }

        private void replacementForLastOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseReplacment frmLicenseReplacment = new frmLicenseReplacment();
            frmLicenseReplacment.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frmManageLocalDrivingLicenseApplications = new frmManageLocalDrivingLicenseApplications();
            frmManageLocalDrivingLicenseApplications.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frmManageDetainedLicenses = new frmManageDetainedLicenses();
            frmManageDetainedLicenses.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();
            frmDetainLicense.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void detainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }
    }
}
