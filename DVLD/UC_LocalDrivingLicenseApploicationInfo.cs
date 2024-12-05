using ApplicationsBusinessLayer;
using ApplicationTypesBusinessLayer;
using LicensesBusinessLayer;
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
    public partial class UC_LocalDrivingLicenseApploicationInfo : UserControl
    {

        public int LocalDrivingLicenseApplicationID { set; get; }
        clsApplication _Application = new clsApplication();
        public UC_LocalDrivingLicenseApploicationInfo()
        {
            InitializeComponent();

        }


        private void UC_LocalDrivingLicenseApploicationInfo_Load(object sender, EventArgs e)
        {


        }

        public void Set(int LocalApplicationID)
        {
            LocalDrivingLicenseApplicationID = LocalApplicationID;

            _Application = clsApplication.Find(clsLocalDrivingLicenseApplication.GetApplicationIDByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID));
            _SetApplicationBasicInfo();
            _SetDrivingLicenseApplicationInfo();
        }

        void _SetApplicationBasicInfo()
        {
            lblBasicApplicationID.Text = _Application.ApplicationID.ToString();
            lblDate.Text               = _Application.ApplicationDate.ToShortDateString();
            lblStatuesDate.Text        = _Application.LastStatusDate.ToShortDateString();
            lblFees.Text               = clsApplicationType.GetApplicationFeesByID(_Application.ApplicationTypeID).ToString("00");
            lblType.Text               = clsApplicationType.GetApplicationTypeNameByID(_Application.ApplicationTypeID);
            lblApplicant.Text          = clsPeople.GetPersonFullNameByID(_Application.ApplicantPersonID).ToString();
            lblCreatedBy.Text          = clsUser.GetUserNameByID(_Application.CreatedByUserID);

        }

        void _SetDrivingLicenseApplicationInfo()
        {

            lblLocalApplicationID.Text = LocalDrivingLicenseApplicationID.ToString();
            lblApplicatoinClass.Text   = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseClassByID(LocalDrivingLicenseApplicationID);
            lblStatus.Text             = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseStatusByID(LocalDrivingLicenseApplicationID);
            lblPassedTests.Text        = clsLocalDrivingLicenseApplication.GetLocalDrivingLicensePassedTestsCountByID(LocalDrivingLicenseApplicationID).ToString();

            if (clsApplication.IsApplicationHasALicense(_Application.ApplicationID))
                linklableShowLicenseInfo.Enabled = true;

            else
                linklableShowLicenseInfo.Enabled = false;

        }       


        private void linkLabelViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo frmPersonInfo = new frmPersonInfo(_Application.ApplicantPersonID);
            frmPersonInfo.ShowDialog();
        }


        private void linklableShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(clsLicense.GetLicenseIDByApplicationID(_Application.ApplicationID));
            frmDriverLicenseInfo.ShowDialog();

        }
    }
}
