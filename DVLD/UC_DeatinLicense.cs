using ApplicationTypesBusinessLayer;
using DetainedLicensesBusinessLayer;
using DriversBusinessLayer;
using LicensesBusinessLayer;
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
    public partial class UC_DeatinLicense : UserControl
    {
        clsLicense _CurrentLocalLicense = new clsLicense();

        public delegate void DataBackEventHandler(object sender, bool DetainCompleted);

        public static event DataBackEventHandler DataBack;

        enum enLicenseStatus { enDetained = 1, enUnDetained= 2 }
        public UC_DeatinLicense()
        {
            InitializeComponent();
        }

        void _LoadDetainInfoabels()
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsUser.GetUserNameByID(_CurrentLocalLicense.CreatedByUserID).ToString();
            lblLID.Text = _CurrentLocalLicense.LicenseID.ToString();
        }
        void _SetDeatinedLicenseData(string NotcieMessage)
        {
            MessageBox.Show(NotcieMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            uC_DriverLicenseInfo1.SetDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            _LoadDetainInfoabels();
            linklableShowNewLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = true;
            btnDetian.Enabled = false;
        }

        void _SetUnDeatinedLicenseData()
        {

            uC_DriverLicenseInfo1.SetDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            _LoadDetainInfoabels();
            linklableShowNewLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = true;
            btnDetian.Enabled = true;
        }



        enLicenseStatus GetLicenseStatus()
        {
            enLicenseStatus licenseStatus = new enLicenseStatus();

            if (clsLicense.IsLicenseDetained(_CurrentLocalLicense.LicenseID))
                licenseStatus = enLicenseStatus.enDetained;

            else licenseStatus = enLicenseStatus.enUnDetained;

            return licenseStatus;
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
                _SetUnDeatinedLicenseData();
            }

            else
            {
                NoticeMessage = "License is Already Detained ! , Choose another one";
                _SetDeatinedLicenseData(NoticeMessage);

            }


        }
        bool _IsThereEmptyFields(TextBox textBox)
        {

            return (string.IsNullOrEmpty(textBox.Text));

        }
        private void tbDetainFees_Validating(object sender, CancelEventArgs e)
        {
            if (_IsThereEmptyFields(tbDetainFees))
            {
                e.Cancel = true;
                tbDetainFees.Select(0, tbDetainFees.Text.Length);
                epDetainFees.SetError(tbDetainFees, "Please Enter Detain Fees !");
            }
        }

        private void tbSearch_Validating(object sender, CancelEventArgs e)
        {
            if (_IsThereEmptyFields(tbSearch))
            {
                e.Cancel = true;
                tbSearch.Select(0, tbSearch.Text.Length);
                epEmptyField.SetError(tbSearch, "Please Enter License ID !");
            }
        }

        private void tbSearch_Validated(object sender, EventArgs e)
        {
            epEmptyField.SetError(tbSearch, "");

        }

        private void tbDetainFees_Validated(object sender, EventArgs e)
        {
            epEmptyField.SetError(tbDetainFees, "");

        }

        private void UC_DeatinLicense_Load(object sender, EventArgs e)
        {
            linklableShowNewLicenseInfo.Enabled = linkLabelShowLicenseHistory.Enabled = false;
            btnDetian.Enabled = false;
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NatoinalNo = clsDriver.GetNationalNoByDriverID(_CurrentLocalLicense.DriverID);
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(NatoinalNo);
            frmShowPersonLicensesHistory.ShowDialog();
        }

        private void linklableShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(_CurrentLocalLicense.LicenseID);
            frmDriverLicenseInfo.ShowDialog();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        clsDetainedLicense _DetainLicense()
        {
            
          clsDetainedLicense DetainedLicense = new clsDetainedLicense();

            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.FineFees = decimal.Parse(tbDetainFees.Text);
            DetainedLicense.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            DetainedLicense.IsReleased = false;
            DetainedLicense.LicenseID = _CurrentLocalLicense.LicenseID;

            DetainedLicense.ReleasedByUserID = null; DetainedLicense.ReleaseDate = null;
            DetainedLicense.ReleaseApplicationID = null;

            DetainedLicense.Mode = clsDetainedLicense.enMode.AddNew;
            return DetainedLicense;
        }

        private void btnDetian_Click(object sender, EventArgs e)
        {
            if (_IsThereEmptyFields(tbDetainFees))
            {
                MessageBox.Show("Please Fill Detain Fees !!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                var form = this.FindForm();
                if (form != null)
                {
                    form.DialogResult = DialogResult.None;  // Prevent the form from closing
                }
            }

            clsDetainedLicense DetaineLicense = _DetainLicense();

            if (DetaineLicense.Save())
            {
                lblDeatinID.Text = DetaineLicense.DetainID.ToString();

                DialogResult result = MessageBox.Show("License Detained Successfully !, Detain License ID is : [" + DetaineLicense.DetainID + "]", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    

                    var form = this.FindForm();
                    if (form != null)
                    {
                        form.DialogResult = DialogResult.None;  // Prevent the form from closing
                    }

                    DataBack?.Invoke(this, true);

                    linklableShowNewLicenseInfo.Enabled = true;
                    btnDetian.Enabled = false;

                }
            }

        }
    }
}
