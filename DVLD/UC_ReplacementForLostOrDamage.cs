using ApplicationsBusinessLayer;
using ApplicationTypesBusinessLayer;
using DriversBusinessLayer;
using LicenseClassesBusinessLayer;
using LicensesBusinessLayer;
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
    public partial class UC_ReplacementForLostOrDamage : UserControl
    {
        clsLicense _CurrentLocalLicense = new clsLicense();
        int ReplacedLicnseID = 0;

        enum enLicenseStatus { enActive = 1, enInactive = 2 }

        enLicenseStatus GetLicenseStatus()
        {
            enLicenseStatus licenseStatus = new enLicenseStatus();

            if (_CurrentLocalLicense.IsActive)
                licenseStatus = enLicenseStatus.enActive;

            else licenseStatus = enLicenseStatus.enInactive;

            return licenseStatus;
        }

        void _DeactivateLicense()
        {
            _CurrentLocalLicense.IsActive = false;
            _CurrentLocalLicense.Mode = clsLicense.enMode.Update;
            _CurrentLocalLicense.Save();
        }

        int _GetApplicationTypeID()
        {
            /*
                3   Replacement for a Lost Driving License     10.00
                    ------------------------------------------------
                4   Replacement for a Damaged Driving License   5.00
             */
            return (rbDamagedLicense.Checked ? 4 : 3);

        }



        public UC_ReplacementForLostOrDamage()
        {
            InitializeComponent();

        }

        clsApplication _SetApplicationInfo()
        {
            clsApplication _NewApplication = new clsApplication();
            string NationalNo = clsDriver.GetNationalNoByDriverID(clsDriver.GetDriverIDByLicenseID(_CurrentLocalLicense.LicenseID)); ;
            _NewApplication.ApplicantPersonID = clsPeople.GetPersonIDByNationalNo(NationalNo);
            _NewApplication.ApplicationTypeID = _GetApplicationTypeID();
            _NewApplication.ApplicationDate = DateTime.Now;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.ApplicationStatus = 3;
            _NewApplication.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            _NewApplication.PaidFees = clsApplicationType.GetApplicationFeesByID(_GetApplicationTypeID());

            _NewApplication.Mode = clsApplication.enMode.AddNew;

            return _NewApplication;
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
            NewLocalLicense.Notes = "";
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

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {

            _DeactivateLicense();
            clsApplication _NewApplication = _SetApplicationInfo();

            if (_NewApplication.Save())
            {

                clsLicense _NewLicense = _SetNewLocalLicenseInfo(_NewApplication.ApplicationID);

                if (_NewLicense.Save())
                {
                    ReplacedLicnseID = _NewLicense.LicenseID;
                   DialogResult result =  MessageBox.Show("Local License Replaced Successfully !\nNew License ID is : [" + ReplacedLicnseID +"]", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   if(result == DialogResult.OK)
                    {
                        lblReplacedLicenseID.Text = _NewLicense.LicenseID.ToString();
                        lblRenweLicenseApplicationID.Text = _NewApplication.ApplicationID.ToString();
                     
                        var form = this.FindForm();
                        if (form != null)
                        {
                            form.DialogResult = DialogResult.None;  // Prevent the form from closing
                        }
                        
                        linklableShowNewLicenseInfo.Enabled = true;
                        btnIssueReplacement.Enabled = false;
                    }
                }


                else
                    MessageBox.Show("Local License Renew Failed !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }


        void _LoadReplacementApplicationLabels()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblOldLicenseID.Text = _CurrentLocalLicense.LicenseID.ToString();
            lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByID(_GetApplicationTypeID()).ToString("0");
            lblCreatedBy.Text = clsUser.GetUserNameByID(_CurrentLocalLicense.CreatedByUserID).ToString();
        }
        void _SetNotActiveLicenseData(string NotcieMessage)
        {
            MessageBox.Show(NotcieMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            uC_DriverLicenseInfo1.SetDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            _LoadReplacementApplicationLabels();
            linklableShowNewLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = true;
            btnIssueReplacement.Enabled = false;
        }

        void _SetActiveLicenseData()
        {

            uC_DriverLicenseInfo1.SetDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            _LoadReplacementApplicationLabels();
            linklableShowNewLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = true;
            btnIssueReplacement.Enabled = true;
        }

        bool _IsThereEmptyFields()
        {

            return (string.IsNullOrEmpty(tbSearch.Text));

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

            enLicenseStatus licenseStatus = GetLicenseStatus();
            string NoticeMessage;

            if (licenseStatus == enLicenseStatus.enActive)
            {
                _SetActiveLicenseData();
            }

            else
            {
                NoticeMessage = "License is Inactive ! , Choose An Active License";
                _SetNotActiveLicenseData(NoticeMessage);

            }

        }

        private void UC_ReplacementForLostOrDamage_Load(object sender, EventArgs e)
        {
            linklableShowNewLicenseInfo.Enabled = linkLabelShowLicenseHistory.Enabled = false;
            btnIssueReplacement.Enabled = false;
            lblApplicationFees.Text = clsApplicationType.GetApplicationFeesByID(_GetApplicationTypeID()).ToString("0");

        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NatoinalNo = clsDriver.GetNationalNoByDriverID(_CurrentLocalLicense.DriverID);
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(NatoinalNo);
            frmShowPersonLicensesHistory.ShowDialog();
        }

        private void linklableShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(ReplacedLicnseID);
            frmDriverLicenseInfo.ShowDialog();
        }

        private void tbSearch_TextChanged(object sender, KeyPressEventArgs e)
        {
                
      
                
        }

        private void tbSearch_Validating(object sender, CancelEventArgs e)
        {
            if (_IsThereEmptyFields())
            {
                e.Cancel = true;
                tbSearch.Select(0, tbSearch.Text.Length);
                epEmptyFieldCheck.SetError(tbSearch, "Please Enter License ID !");
            }

        }

        private void tbSearch_Validated(object sender, EventArgs e)
        {
            epEmptyFieldCheck.SetError(tbSearch, "");
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblReplcaementType.Text = "Replacement For Damaged License";
            lblApplicationFees.Text = "5";
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblReplcaementType.Text = "Replacement For Lost License";
            lblApplicationFees.Text = "10";
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
