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
using UsersBusinessLayer;

namespace DVLD
{
    public partial class UC_RenewDrivingLicense : UserControl
    {
        clsLicense _CurrentLocalLicense = new clsLicense();
        int NewLicnseID = 0;

        enum enLicenseStatus { enActive = 1 , enInactive = 2 }
        public UC_RenewDrivingLicense()
        {
            InitializeComponent();
        }

        bool IsLicenseExpired(DateTime ExpirationDate)
        {

        if (DateTime.Compare(ExpirationDate, DateTime.Now.Date) < 0)
        {
            if(_CurrentLocalLicense.IsActive)
                return true;

            else
                return false;
        }
        
            else
                return false;

        }

        void _LoadRenewApplicationLabels()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text       = _CurrentLocalLicense.IssueDate.ToShortDateString();
            lblOldLicenseID.Text    = _CurrentLocalLicense.LicenseID.ToString();
            lblExpDate.Text         = _CurrentLocalLicense.IssueDate.AddYears(clsLicenseClasse.GetLicenseClassDefaultValidityLengthByID(_CurrentLocalLicense.LicenseClass)).ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByID(2).ToString("0");
            lblLicenseFees.Text     = _CurrentLocalLicense.PaidFees.ToString("00");
            lblTotalFees.Text       = (decimal.Parse(lblApplicationFees.Text) + decimal.Parse(lblLicenseFees.Text)).ToString("00"); 
            lblCreatedBy.Text       =  clsUser.GetUserNameByID(_CurrentLocalLicense.CreatedByUserID).ToString();
        }

        enLicenseStatus GetLicenseStatus()
        {
            enLicenseStatus licenseStatus = new enLicenseStatus();

            if (_CurrentLocalLicense.IsActive)
                licenseStatus = enLicenseStatus.enActive;

            else licenseStatus = enLicenseStatus.enInactive;

            return licenseStatus;
        }

        void _SetNotExpiredOrInActiveLicenseData(string NotcieMessage)
        {
            MessageBox.Show(NotcieMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            uC_DriverLicenseInfo1.SetDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            _LoadRenewApplicationLabels();
            linklableShowNewLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = true;
            btnRenew.Enabled = false;
        }

        void _SetExpiredAndActiveLicenseData()
        {

            uC_DriverLicenseInfo1.SetDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            _LoadRenewApplicationLabels();
            linklableShowNewLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = true;
            btnRenew.Enabled = true;
        }
        private void btnSearchLicense_Click(object sender, EventArgs e)
        {
              int LicenseID = int.Parse(tbSearch.Text.Trim());
            _CurrentLocalLicense = clsLicense.Find(LicenseID);


            if (_CurrentLocalLicense == null)
            {
                MessageBox.Show("License Does Not Exist !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (IsLicenseExpired(_CurrentLocalLicense.ExpirationDate))
                {
                    _SetExpiredAndActiveLicenseData();
                }

            else
            {

                enLicenseStatus licenseStatus = GetLicenseStatus();
                string NoticeMessage;

                if (licenseStatus == enLicenseStatus.enActive)
                {
                    NoticeMessage = "License Not Expired Yet ! , Expiratoin Date in : [ " + _CurrentLocalLicense.ExpirationDate.ToShortDateString() + " ]";
                    _SetNotExpiredOrInActiveLicenseData(NoticeMessage);

                }

                else
                {
                    NoticeMessage = "License is Inactive ! , Choose An Active One";
                    _SetNotExpiredOrInActiveLicenseData(NoticeMessage);

                }

            }
            

            
        }

        clsLicense _SetNewLocalLicenseInfo(int ApplicationID)
        {
            clsLicense NewLocalLicense = new clsLicense();
            clsApplication Application = clsApplication.Find(ApplicationID);
            NewLocalLicense.ApplicationID = Application.ApplicationID;
            NewLocalLicense.DriverID = _CurrentLocalLicense.DriverID;
            NewLocalLicense.LicenseClass = _CurrentLocalLicense.LicenseClass;
            NewLocalLicense.IssueDate = DateTime.Now;

            int ValididtyLength = clsLicenseClasse.GetLicenseClassDefaultValidityLengthByID(NewLocalLicense.LicenseClass);

            NewLocalLicense.ExpirationDate = NewLocalLicense.IssueDate.AddYears(ValididtyLength).Date;
            NewLocalLicense.Notes = tbNotes.Text.Trim();
            NewLocalLicense.PaidFees = clsLicenseClasse.GetLicenseClassFeesByID(NewLocalLicense.LicenseClass);
            NewLocalLicense.IsActive = true;
            NewLocalLicense.IssueReason = (byte)Application.ApplicationTypeID;
            NewLocalLicense.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            NewLocalLicense.Mode = clsLicense.enMode.AddNew;


            Application.LastStatusDate = DateTime.Now;
            Application.ApplicationStatus = 3;
            Application.Mode = clsApplication.enMode.AddNew;
            Application.Save();

            return NewLocalLicense;
        }

   

        clsApplication _SetRenewApplicationInfo()
        {
            clsApplication _NewApplication = new clsApplication();
            string NationalNo = clsDriver.GetNationalNoByDriverID(clsDriver.GetDriverIDByLicenseID(_CurrentLocalLicense.LicenseID)); ;
            _NewApplication.ApplicantPersonID = clsPeople.GetPersonIDByNationalNo(NationalNo);
            _NewApplication.ApplicationTypeID = 2; // 2 Is Renew License Applicatoin Type
            _NewApplication.ApplicationDate = DateTime.Now;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.ApplicationStatus = 3;
            _NewApplication.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            _NewApplication.PaidFees = decimal.Parse(lblTotalFees.Text);

            _NewApplication.Mode = clsApplication.enMode.AddNew;

            return _NewApplication;
        }
        void _DeactivateLicense()
        {
            _CurrentLocalLicense.IsActive = false;
            _CurrentLocalLicense.Mode = clsLicense.enMode.Update;
            _CurrentLocalLicense.Save();
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
           
            _DeactivateLicense();
            clsApplication _NewApplication = _SetRenewApplicationInfo();

            if (_NewApplication.Save())
            {

               clsLicense _NewLicense = _SetNewLocalLicenseInfo(_NewApplication.ApplicationID);
              
              if (_NewLicense.Save())
              {
                 DialogResult result = MessageBox.Show("Local License Renewd Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                if(result == DialogResult.OK)
                    {
                        lblRenewedLicenseID.Text = _NewLicense.LicenseID.ToString();
                        NewLicnseID = _NewLicense.LicenseID;
                        lblRenweLicenseApplicationID.Text = _NewApplication.ApplicationID.ToString();

                        var form = this.FindForm();
                        if (form != null)
                        {
                            form.DialogResult = DialogResult.None;  // Prevent the form from closing
                        }

                        linklableShowNewLicenseInfo.Enabled = true;
                        btnRenew.Enabled = false;

                    }
                
              }
              
              
              else
                  MessageBox.Show("Local License Renew Failed !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }

        private void UC_RenewDrivingLicense_Load(object sender, EventArgs e)
        {
            linklableShowNewLicenseInfo.Enabled = linkLabelShowLicenseHistory.Enabled = false;
            btnRenew.Enabled = false;
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NatoinalNo = clsDriver.GetNationalNoByDriverID(_CurrentLocalLicense.DriverID);
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(NatoinalNo);
            frmShowPersonLicensesHistory.ShowDialog();
        }

        private void linklableShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(NewLicnseID);
            frmDriverLicenseInfo.ShowDialog();
        }
    }
}
