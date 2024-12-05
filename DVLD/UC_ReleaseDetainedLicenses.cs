using ApplicationsBusinessLayer;
using ApplicationTypesBusinessLayer;
using DetainedLicensesBusinessLayer;
using DriversBusinessLayer;
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
    public partial class UC_ReleaseDetainedLicenses : UserControl
    {
        int _DetainID = -1;
        public UC_ReleaseDetainedLicenses()
        {
            InitializeComponent();

        

        }

        void DisalbleSearchingFilter(){ gpFilter.Enabled = false; }
        public void SetDetainID(int DeatainID)
        {
            _DetainID = DeatainID;

            if (_DetainID != -1)
            {
                _CurrentLocalLicense = clsLicense.Find(clsDetainedLicense.GetLicenseIDByDetainID(_DetainID));
                uC_DriverLicenseInfo1.SetDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
               _SetDetainedLicenseData();
                DisalbleSearchingFilter();
            }
        }

        clsLicense _CurrentLocalLicense = new clsLicense();

        public delegate void DataBackEventHandler(object sender, bool ReleaseCompleted);

        public static event DataBackEventHandler DataBack;

        enum enLicenseStatus { enDetained = 1, enUnDetained = 2 }
        void _LoadDetainInfoaLabels()
        {
            // 5    Release Detained Driving Licsense   15.00
            int DetainID = clsDetainedLicense.GetDetainIDByLicenseID(_CurrentLocalLicense.LicenseID);
            lblDeatinID.Text = DetainID.ToString();
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsUser.GetUserNameByID(_CurrentLocalLicense.CreatedByUserID).ToString();
            lblLID.Text = _CurrentLocalLicense.LicenseID.ToString();
            lblApplicatoinFees.Text = clsApplicationType.GetApplicationFeesByID(5).ToString("00"); // 5 Is Release App ID
            lblFineFees.Text        = clsDetainedLicense.GetFineFeesByDetainID(DetainID).ToString("00");
            lblTotalFees.Text = (clsApplicationType.GetApplicationFeesByID(5) + clsDetainedLicense.GetFineFeesByDetainID(DetainID)).ToString("00");

        }

        enLicenseStatus GetLicenseStatus()
        {
            enLicenseStatus licenseStatus = new enLicenseStatus();

            if (clsLicense.IsLicenseDetained(_CurrentLocalLicense.LicenseID))
                licenseStatus = enLicenseStatus.enDetained;

            else licenseStatus = enLicenseStatus.enUnDetained;

            return licenseStatus;
        }

        void _SetDetainedLicenseData()
        {

            uC_DriverLicenseInfo1.SetDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            _LoadDetainInfoaLabels();
            linklableShowNewLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = true;
            btnRelease.Enabled = true;
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

                if (licenseStatus == enLicenseStatus.enUnDetained)
                {
                    NoticeMessage = "License Is Not Detained ! , Choose Another One";
                    MessageBox.Show(NoticeMessage , "" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                }

                else
                    _SetDetainedLicenseData();

            
        }
        clsApplication _SetRelaeaseApplicationInfo()
        {
            clsApplication _NewApplication = new clsApplication();
            string NationalNo = clsDriver.GetNationalNoByDriverID(clsDriver.GetDriverIDByLicenseID(_CurrentLocalLicense.LicenseID)); ;
            _NewApplication.ApplicantPersonID = clsPeople.GetPersonIDByNationalNo(NationalNo);
            _NewApplication.ApplicationTypeID = 5; // 5 Is Renew License Applicatoin Type
            _NewApplication.ApplicationDate = DateTime.Now;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.ApplicationStatus = 3;
            _NewApplication.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            _NewApplication.PaidFees = decimal.Parse(lblTotalFees.Text);

            _NewApplication.Mode = clsApplication.enMode.AddNew;

            return _NewApplication;
        }
        bool _ReleaseLicense(int ApplicationID)
        {
            int DetainID = clsDetainedLicense.GetDetainIDByLicenseID(_CurrentLocalLicense.LicenseID);
            clsDetainedLicense detainedLicense = clsDetainedLicense.Find(DetainID);

            detainedLicense.IsReleased = true;
            detainedLicense.ReleasedByUserID = clsCurrentUser.CurrentUser.UserID;
            detainedLicense.ReleaseDate = DateTime.Now;
            detainedLicense.ReleaseApplicationID = ApplicationID;
            detainedLicense.LicenseID = _CurrentLocalLicense.LicenseID;
            detainedLicense.DetainID = DetainID;
            detainedLicense.FineFees = decimal.Parse(lblFineFees.Text);
            detainedLicense.DetainDate = detainedLicense.DetainDate;
            detainedLicense.Mode = clsDetainedLicense.enMode.Update;

            return detainedLicense.Save();

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            clsApplication _NewApplication = _SetRelaeaseApplicationInfo();

            if (_NewApplication.Save())
            {
                lblApplicationID.Text = _NewApplication.ApplicationID.ToString();

                if (_ReleaseLicense(_NewApplication.ApplicationID))
                {
                    DialogResult result = MessageBox.Show("License Release Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBack?.Invoke(this, true);
                    if (result == DialogResult.OK)
                    {

                        var form = this.FindForm();
                        if (form != null)
                        {
                            form.DialogResult = DialogResult.None;  // Prevent the form from closing
                        }

                        linklableShowNewLicenseInfo.Enabled = true;
                        btnRelease.Enabled = false;

                    }
                }             

                else
                    MessageBox.Show("License Release Failed !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void tbSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                e.Cancel = true;
                tbSearch.Select(0, tbSearch.Text.Length);
                epEmptyField.SetError(tbSearch , "Please Enter License ID !");
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void tbSearch_Validated(object sender, EventArgs e)
        {
            epEmptyField.SetError(tbSearch, "");

        }

        private void linklableShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            frmDriverLicenseInfo.ShowDialog();
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NationalNo = clsDriver.GetNationalNoByDriverID(_CurrentLocalLicense.DriverID);
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(NationalNo);
            frmShowPersonLicensesHistory.ShowDialog();
        }

        private void UC_ReleaseDetainedLicenses_Load(object sender, EventArgs e)
        {
            if(_DetainID == -1)
            {
                linkLabelShowLicenseHistory.Enabled = linklableShowNewLicenseInfo.Enabled = false;
                btnRelease.Enabled = false;
            }
            
        }
    }
}
