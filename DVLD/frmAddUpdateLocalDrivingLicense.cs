using ApplicationsBusinessLayer;
using ApplicationTypesBusinessLayer;
using LocalDrivingLicenseApplicationsBusinessLayer;
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
    public partial class frmAddUpdateLocalDrivingLicense : Form
    {
        string SelectedPersonNationalNo = "";
        clsLocalDrivingLicenseApplication _CurrentLocalDrivingApplication = new clsLocalDrivingLicenseApplication();
        clsApplication _CurrentApplication = new clsApplication();
        clsApplication.enMode _CurrentMode = new clsApplication.enMode();
        public frmAddUpdateLocalDrivingLicense(int LocalDrivingApplicationID = -1)
        {
            InitializeComponent();

            if (LocalDrivingApplicationID == -1)
                _CurrentMode = clsApplication.enMode.AddNew;

            else
            {
                _CurrentMode = clsApplication.enMode.Update;
                _CurrentLocalDrivingApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingApplicationID);
                _CurrentApplication = clsApplication.Find(clsLocalDrivingLicenseApplication.GetApplicationIDByLocalDrivingApplicationID(LocalDrivingApplicationID));
                _LoadPersonWithFilterInfo();

            }



            tpAddUpdateLocalDVLD.Selecting += new TabControlCancelEventHandler(tabPageApplicationInfo_Enter);

        }

        private void frmAddUpdateLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            if(_CurrentMode == clsApplication.enMode.AddNew)
            {
                btnSave.Enabled = false;
                cbLicenseClasses.SelectedItem = "Class 3 - Ordinary driving license";

            }

            else
            {
                _LoadLocalApplicationInfo();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsPersonSelected.IsPersonSelected)
            {
        
                tpAddUpdateLocalDVLD.SelectedIndex++;
                btnSave.Enabled = true;
            }


            else
                MessageBox.Show("Please Select A Person", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tabPageApplicationInfo_Enter(object sender, TabControlCancelEventArgs e)
        {
            if (!clsPersonSelected.IsPersonSelected)
            {
                e.Cancel = true;  // Cancel the selection
                return;
            }

            lblApplicationDate.Text = DateTime.Today.Date.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByID(1).ToString("00");
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.UserName;

           

        }

        void _SetCurrentApplicationInfo()
        {
            if (_CurrentMode == clsApplication.enMode.AddNew)
            {
                _CurrentApplication.ApplicantPersonID = clsPersonSelected.PersonID;
                _CurrentApplication.ApplicationDate = _CurrentApplication.LastStatusDate = DateTime.Today;
                _CurrentApplication.ApplicationTypeID = 1;
                _CurrentApplication.ApplicationStatus = 1;
                _CurrentApplication.PaidFees = clsApplicationType.GetApplicationFeesByID(_CurrentApplication.ApplicationTypeID);
                _CurrentApplication.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;

                _CurrentApplication.Mode = clsApplication.enMode.AddNew;
            }

            else
                _CurrentApplication.Mode = clsApplication.enMode.Update;

        }
        void _SetCurrentLocalApplication(int ApplicationID)
        {
            if (_CurrentMode == clsApplication.enMode.AddNew)
            {
                _CurrentLocalDrivingApplication.ApplicationID = ApplicationID;
                _CurrentLocalDrivingApplication.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;

                _CurrentLocalDrivingApplication.Mode = clsLocalDrivingLicenseApplication.enMode.AddNew;
            }

            else
            {
                _CurrentLocalDrivingApplication.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;
                _CurrentLocalDrivingApplication.Mode = clsLocalDrivingLicenseApplication.enMode.Update;

            }

        }

        void _LoadPersonWithFilterInfo()
        {
            uC_PersonInfoWithFilter1.IsUpdateMode = true;
            UC_PersonInfoWithFilter.clsPersonID.PersonID = _CurrentApplication.ApplicantPersonID;
            clsPersonSelected.IsPersonSelected = true;
            uC_PersonInfoWithFilter1.DisableFilter();
        }
        void _LoadLocalApplicationInfo()
        {
            lblApplicationID.Text          = _CurrentLocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text        = _CurrentApplication.ApplicationDate.ToString();
            lblApplicationFees.Text        = clsApplicationType.GetApplicationFeesByID(_CurrentApplication.ApplicationTypeID).ToString("00");
            lblCreatedBy.Text              = _CurrentApplication.CreatedByUserID.ToString();
            cbLicenseClasses.SelectedIndex = (_CurrentLocalDrivingApplication.LicenseClassID - 1);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SelectedPersonNationalNo = clsPeople.GetPersonNationalNoByID(clsPersonSelected.PersonID);

            if(!clsLocalDrivingLicenseApplication.IsApplicationClassExist(cbLicenseClasses.SelectedItem.ToString() , SelectedPersonNationalNo))
            {
               
                _SetCurrentApplicationInfo();
                if (_CurrentApplication.Save())
                {
                    _SetCurrentLocalApplication(_CurrentApplication.ApplicationID);

                    if (_CurrentLocalDrivingApplication.Save())
                    {
                        MessageBox.Show("Data Saved Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblApplicationID.Text = _CurrentLocalDrivingApplication.LocalDrivingLicenseApplicationID.ToString();
                    }

                    else
                        MessageBox.Show("Data Saved Failed !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }

            else
               MessageBox.Show("Person has already a licese with the same applied driving class, Choose different driving class","Not Allowed" ,MessageBoxButtons.OK , MessageBoxIcon.Error);

            clsPersonSelected.IsPersonSelected = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsPersonSelected.IsPersonSelected = false;

        }
    }
}
