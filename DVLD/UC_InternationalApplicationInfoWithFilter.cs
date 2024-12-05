using ApplicationsBusinessLayer;
using ApplicationTypesBusinessLayer;
using DriversBusinessLayer;
using InternationalLicensesBusinessLayer;
using LicenseClassesBusinessLayer;
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

namespace DVLD
{
    public partial class UC_InternationalApplicationInfoWithFilter : UserControl
    {
        int _CurrentLicenseID = 0;
        enum enLicenseStatus { enExistWithInternational = 1 , enExistButNotOrdinary , enExistButDetained , enExistAndReadyForIssue , enDoesNotExist  }
        public UC_InternationalApplicationInfoWithFilter()
        {
            InitializeComponent();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If it's not a control key or a digit, suppress the key press
                e.Handled = true;
            }
        }

        void _SetInternatoinalAppLabels()
        {
            int LicenseClassID = clsLicense.GetLicenseClassIDByLicenseID(_CurrentLicenseID);

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text       = DateTime.Now.ToShortDateString();
            lblLocalLicenseID.Text  = _CurrentLicenseID.ToString();
            lblFees.Text            = clsApplicationType.GetApplicationFeesByID(6).ToString();
            lblCreatedBy.Text       = clsCurrentUser.CurrentUser.UserName;
            lblExpDate.Text         = DateTime.Now.AddYears(clsLicenseClasse.GetLicenseClassDefaultValidityLengthByID(LicenseClassID)).Date.ToShortDateString();
            btnIssue.Enabled = false;
        }
        clsInternationalLicense _SetInternationlApplicatonInfo(int LicenseID , int ApplicationID)
        {
            clsInternationalLicense internationalLicense = new clsInternationalLicense();

            internationalLicense.ApplicationID = ApplicationID;
            internationalLicense.IssuedUsingLocalLicenseID = LicenseID;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1).Date;
            internationalLicense.DriverID = clsDriver.GetDriverIDByLicenseID(LicenseID);
            internationalLicense.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            internationalLicense.IsActive = true;

            internationalLicense.Mode = clsInternationalLicense.enMode.AddNew;

            return internationalLicense;
        }

        enLicenseStatus GetLicenseStatus(int LicenseID)
        {
            enLicenseStatus licenseStatus = new enLicenseStatus();


            if (clsLicense.isLicenseExist(LicenseID) && clsLicense.IsLicenseHasInternationalLicense(clsDriver.GetDriverIDByLicenseID(LicenseID)))
                licenseStatus =  enLicenseStatus.enExistWithInternational;

            else if (clsLicense.isLicenseExist(LicenseID) && clsLicense.GetLicenseClassIDByLicenseID(LicenseID) != 3)
                licenseStatus =  enLicenseStatus.enExistButNotOrdinary;

            else if (clsLicense.isLicenseExist(LicenseID) && clsLicense.IsLicenseDetained(LicenseID))
                licenseStatus = enLicenseStatus.enExistButDetained;

            else if (clsLicense.isLicenseExist(LicenseID))
                licenseStatus = enLicenseStatus.enExistAndReadyForIssue;

            else
                licenseStatus = enLicenseStatus.enDoesNotExist;

            return licenseStatus;
        }

        private void btnSearchLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = int.Parse(tbSearch.Text);

            enLicenseStatus LicenseStatus = GetLicenseStatus(LicenseID);

            switch (LicenseStatus)
            {
                case enLicenseStatus.enExistWithInternational:
                    {
                        _CurrentLicenseID = LicenseID;
                        MessageBox.Show("Person Already Has International License !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnIssue.Enabled = false;
                        uC_DriverLicenseInfo1.SetDriverLicenseInfo(LicenseID);

                        _SetInternatoinalAppLabels();
                        linkLabelShowLicenseHistory.Enabled = linklableShowLicenseInfo.Enabled = true;
                        break;
                    }

                case enLicenseStatus.enExistButNotOrdinary:
                    {
                        _CurrentLicenseID = LicenseID;
                        MessageBox.Show("License Must Be In The Ordinary Class !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnIssue.Enabled = false;
                        linklableShowLicenseInfo.Enabled = false;
                        linkLabelShowLicenseHistory.Enabled = true;
                        uC_DriverLicenseInfo1.SetDriverLicenseInfo(LicenseID);
                        _SetInternatoinalAppLabels();

                        break;
                    }

                case enLicenseStatus.enExistButDetained:
                    {
                        _CurrentLicenseID = -1;
                        MessageBox.Show("License Does Not Active !!, Please Choose An Active One ..", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnIssue.Enabled = false;
                        linklableShowLicenseInfo.Enabled = false;
                        linkLabelShowLicenseHistory.Enabled = true;
                        _SetInternatoinalAppLabels();
                        break;
                    }

                case enLicenseStatus.enExistAndReadyForIssue:
                    {
                        _CurrentLicenseID = LicenseID;
                        uC_DriverLicenseInfo1.SetDriverLicenseInfo(LicenseID);
                        linklableShowLicenseInfo.Enabled = false;
                        btnIssue.Enabled = true;
                        linkLabelShowLicenseHistory.Enabled = true;
                        break;
                    }

                case enLicenseStatus.enDoesNotExist:
                    {
                        _CurrentLicenseID = -1;
                        MessageBox.Show("License Does Not Exist !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnIssue.Enabled = false;
                        linkLabelShowLicenseHistory.Enabled = linklableShowLicenseInfo.Enabled = false;
                        _SetInternatoinalAppLabels();
                        break;
                    }
            }
        }

        clsApplication _SetNewApplicationINfo()
        {

            clsApplication _NewApplication = new clsApplication();
            string NationalNo = clsDriver.GetNationalNoByDriverID(clsDriver.GetDriverIDByLicenseID(_CurrentLicenseID)); ;
            _NewApplication.ApplicantPersonID = clsPeople.GetPersonIDByNationalNo(NationalNo);
            _NewApplication.ApplicationTypeID = 6;
            _NewApplication.ApplicationDate = DateTime.Now;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.ApplicationStatus = 3;
            _NewApplication.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            _NewApplication.PaidFees        = clsApplicationType.GetApplicationFeesByID(6);

            _NewApplication.Mode = clsApplication.enMode.AddNew;

            return _NewApplication;
        }
        private void UC_InternationalApplicationInfoWithFilter_Load(object sender, EventArgs e)
        {
            _SetInternatoinalAppLabels();
        }

        private void linklableShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int DriverID = clsDriver.GetDriverIDByLicenseID(_CurrentLicenseID);
            frmInternationalDriverLicenseInfo frmInternationalDriverLicenseInfo = new frmInternationalDriverLicenseInfo(clsInternationalLicense.GetInternationalLicenseIDByDriverID(DriverID));
            frmInternationalDriverLicenseInfo.ShowDialog();
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NationalNo = clsDriver.GetNationalNoByDriverID(clsDriver.GetDriverIDByLicenseID(_CurrentLicenseID)); ;
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(NationalNo);
            frmShowPersonLicensesHistory.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsApplication NewApplication = _SetNewApplicationINfo(); 

            if (NewApplication.Save())
            {
                clsInternationalLicense NewInternationalLicense = _SetInternationlApplicatonInfo(_CurrentLicenseID , NewApplication.ApplicationID);
                if (NewInternationalLicense.Save())
                {
                   DialogResult result =  MessageBox.Show("International Licesne Issued Successfully With ID [ "+ NewInternationalLicense.InternationalLicenseID + " ]", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblInterntionalApplicationID.Text = NewApplication.ApplicationID.ToString();
                    lblInternationalLicenseID.Text    = NewInternationalLicense.InternationalLicenseID.ToString();
                    _SetInternatoinalAppLabels();
                    linklableShowLicenseInfo.Enabled = true;                      

                }

                else
                    MessageBox.Show("International License Saving Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
                MessageBox.Show("Application Saving Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
