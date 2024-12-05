using ApplicationsBusinessLayer;
using DriversBusinessLayer;
using LicensesBusinessLayer;
using LocalDrivingLicenseApplicationsBusinessLayer;
using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAppointmentsBusinessLayer;

namespace DVLD
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {

        enum enApplicationStatus { enNew = 1 , enNewPassedAllTests , enCompleted , enCanceled , enCanceledWithoutLicense }
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            tbSearch.Visible = false;
            _LoadLocalDrivingApplicatoins();
        }

        void _LoadLocalDrivingApplicatoins()
        {
            dgvLocalApplicatoins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocalApplicatoins.DataSource          = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications_View();
            lblNumberOfRecords.Text                  = dgvLocalApplicatoins.RowCount.ToString();
        }

        private bool IsNumeric(string value)
        {
            double result;
            return double.TryParse(value, out result);
        }
        private void tbSearch_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
                epSearchInputValidation.SetError(textBox, "");

            else if (cbFilter.SelectedItem.ToString() == "L.D.L AppID")
            {
                if (!IsNumeric(cbFilter.SelectedItem.ToString()))
                {
                    e.Cancel = true;
                    textBox.Select(0, textBox.Text.Length);
                    epSearchInputValidation.SetError(textBox, "Please enter a valid numeric value.");
                }

            }
        }

        private void tbSearch_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            epSearchInputValidation.SetError(textBox, "");
        }
        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicense frmAddUpdateLocalDrivingLicense = new frmAddUpdateLocalDrivingLicense();
            frmAddUpdateLocalDrivingLicense.ShowDialog();
        }

        private void cbFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                tbSearch.Visible = false;
                _LoadLocalDrivingApplicatoins();
            }

            else tbSearch.Visible = true;
        }

        private void tbSearch_TextChanged_1(object sender, EventArgs e)
        {
            string SearchingInfo = tbSearch.Text.Trim();

            dgvLocalApplicatoins.DataSource = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalApplicationInfo frmShowLocalApplicationInfo = new frmShowLocalApplicationInfo((int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value);
            frmShowLocalApplicationInfo.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDrivingLicenseApplication.GetApplicationIDByLocalDrivingApplicationID((int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value);
            int LicenseID = clsLicense.GetLicenseIDByApplicationID(ApplicationID); 
            frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(LicenseID);
            frmDriverLicenseInfo.ShowDialog();

        }

        enApplicationStatus _DetermineApplicationStatus(string LocalApplicationStatus , int NumberOfPassedTests , string NationalNo)
        {

            if (LocalApplicationStatus == "Completed") return enApplicationStatus.enCompleted;

            else if (LocalApplicationStatus == "New" && (NumberOfPassedTests != 3)) return enApplicationStatus.enNew;

            else if (LocalApplicationStatus == "New" && (NumberOfPassedTests == 3)) return enApplicationStatus.enNewPassedAllTests;

            else if ((LocalApplicationStatus == "Cancelled" && !clsDriver.IsDriverExist(NationalNo)) || (LocalApplicationStatus == "Cancelled" && NumberOfPassedTests != 3))
                return enApplicationStatus.enCanceledWithoutLicense;

         //   else if (LocalApplicationStatus == "Cancelled" && NumberOfPassedTests == 3 ) return enApplicationStatus.enCanceledWithoutLicense;

            else return enApplicationStatus.enCanceled;



        }

        void _ScheduleTestVaildation(int NumberOfPassedTests)
        {

            switch (NumberOfPassedTests)
            {
                case 3:
                    {
                        scheduleTestToolStripMenuItem.Enabled = false;
                        return;

                    }


                case 2:
                    {
                        scheduleStreetTestToolStripMenuItem.Enabled  = true;
                        scheduleVisionTestToolStripMenuItem.Enabled  = false;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        return;
                    }

                case 1:
                    {
                        scheduleWrittenTestToolStripMenuItem.Enabled = true;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;
                        scheduleVisionTestToolStripMenuItem.Enabled  = false;
                        return;
                    }


                case 0:
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled  = true;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled  = false;
                        return;
                    }


            }






        }
        private void cmsLocalDrivingLicenseApplications_Opening(object sender, CancelEventArgs e)
        {

            string SelectedApplicationStatus = (string)dgvLocalApplicatoins.CurrentRow.Cells[6].Value ; int NumOfPassedTests = (int)dgvLocalApplicatoins.CurrentRow.Cells[5].Value;
            string NationalNo = (string)dgvLocalApplicatoins.CurrentRow.Cells[2].Value;

            _ScheduleTestVaildation(NumOfPassedTests);
            enApplicationStatus ApplicationStatus = _DetermineApplicationStatus(SelectedApplicationStatus, NumOfPassedTests,NationalNo);
            
            if      (ApplicationStatus == enApplicationStatus.enCompleted)
            {
                showLicenseToolStripMenuItem.Enabled                  = true ;

                editApplicationiToolStripMenuItem.Enabled             = false;
                deleteApplicationToolStripMenuItem.Enabled            = false;
                CancelApplicationlToolStripMenuItem.Enabled           = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled                 = false;

            }
                                        
            else if (ApplicationStatus == enApplicationStatus.enNew)
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled                  = false;

                editApplicationiToolStripMenuItem.Enabled             = true;
                deleteApplicationToolStripMenuItem.Enabled            = true;
                CancelApplicationlToolStripMenuItem.Enabled           = true;
                scheduleTestToolStripMenuItem.Enabled                 = true;


            }
                                        
            else if(ApplicationStatus  == enApplicationStatus.enNewPassedAllTests)
            {
                scheduleTestToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;

                editApplicationiToolStripMenuItem.Enabled             = true;
                deleteApplicationToolStripMenuItem.Enabled            = true;
                CancelApplicationlToolStripMenuItem.Enabled           = true;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;


            }
                                        
            else if (ApplicationStatus == enApplicationStatus.enCanceledWithoutLicense)
            {
                editApplicationiToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                CancelApplicationlToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled  = false;
            }

            else
            {
                editApplicationiToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                CancelApplicationlToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;

            }

        }

        private void CancelApplicationlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ApplicationStatus ==> 1-New 2-Cancelled 3-Completed

            int ApplicationID = clsLocalDrivingLicenseApplication.GetApplicationIDByLocalDrivingApplicationID((int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value);

            clsApplication _CurrentApplication = clsApplication.Find(ApplicationID);
            _CurrentApplication.Mode = clsApplication.enMode.Update;
            _CurrentApplication.ApplicationStatus = 2;

            DialogResult = MessageBox.Show("Are You Sure To Cancel This Application ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(DialogResult == DialogResult.Yes)
            {
                if (_CurrentApplication.Save())
                {
                    MessageBox.Show("Application Cancelled Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadLocalDrivingApplicatoins();
                }

                else
                    MessageBox.Show("Application Cancelation Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }
        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Not Implemented Yet !", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            int LocalDrivingLicenseApplicationID = (int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value;

            DialogResult = MessageBox.Show("Are You Sure To Delete This Application ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.Yes)
            {
                if (!clsTestAppointment.IsApplicationHasAppointments(LocalDrivingLicenseApplicationID))
                {
                    int ApplicationID = clsLocalDrivingLicenseApplication.GetApplicationIDByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID);

                    if (clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(ApplicationID, LocalDrivingLicenseApplicationID))
                    {
                        MessageBox.Show("Application Deleted Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                    MessageBox.Show("Couldn't delete application, Other data depends on it !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            frmManageLocalDrivingLicenseApplications frmManageLocalDrivingLicenseApplications = new frmManageLocalDrivingLicenseApplications();
            frmManageLocalDrivingLicenseApplications.ShowDialog();

        }

        private void editApplicationiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicense frmAddUpdateLocalDrivingLicense = new frmAddUpdateLocalDrivingLicense((int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value);
            frmAddUpdateLocalDrivingLicense.ShowDialog();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value;
            frmTestAppintments frmTestAppintments = new frmTestAppintments(1 , LocalDrivingLicenseApplicationID);
            frmTestAppintments.ShowDialog();
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value;
            frmTestAppintments frmTestAppintments = new frmTestAppintments(2, LocalDrivingLicenseApplicationID);
            frmTestAppintments.ShowDialog();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value;
            frmTestAppintments frmTestAppintments = new frmTestAppintments(3, LocalDrivingLicenseApplicationID);
            frmTestAppintments.ShowDialog();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalApplicatoins.CurrentRow.Cells[0].Value;
            frmIssueDrivingLicenseFirstTime frmIssueDrivingLicenseFirstTime = new frmIssueDrivingLicenseFirstTime(LocalDrivingLicenseApplicationID);
            frmIssueDrivingLicenseFirstTime.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frmManageLocalDrivingLicenseApplications = new frmManageLocalDrivingLicenseApplications();
            frmManageLocalDrivingLicenseApplications.ShowDialog();
            _LoadLocalDrivingApplicatoins();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvLocalApplicatoins.CurrentRow.Cells[2].Value;
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(NationalNo);
            frmShowPersonLicensesHistory.ShowDialog();
        }
    }
}
