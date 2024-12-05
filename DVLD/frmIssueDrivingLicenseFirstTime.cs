using ApplicationsBusinessLayer;
using DriversBusinessLayer;
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
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        int _CurrentLocalDrivingLicenseApplicationID = 0;
        public frmIssueDrivingLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _CurrentLocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            uC_LocalDrivingLicenseApploicationInfo1.Set(LocalDrivingLicenseApplicationID);
        
        }

        clsDriver _SetNewDriverInfo()
        {
            clsDriver NewDriver = new clsDriver();

            NewDriver.PersonID = clsPeople.GetPersonIDByNationalNo(clsPeople.GetPersonNationalNoByLocalDrivingLicenseApplicationID(_CurrentLocalDrivingLicenseApplicationID));
            NewDriver.CreatedDate = DateTime.Now;
            NewDriver.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            NewDriver.Mode = clsDriver.enMode.AddNew;

            return NewDriver;
        }

        clsLicense _SetNewLocalLicenseInfo(int DriverID)
        {
            clsLicense NewLocalLicense = new clsLicense();
            clsApplication Application = clsApplication.Find(clsLocalDrivingLicenseApplication.GetApplicationIDByLocalDrivingApplicationID(_CurrentLocalDrivingLicenseApplicationID));
            NewLocalLicense.ApplicationID = Application.ApplicationID;
            NewLocalLicense.DriverID = DriverID;
            NewLocalLicense.LicenseClass = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseIDClassByID(_CurrentLocalDrivingLicenseApplicationID);
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
            Application.Mode = clsApplication.enMode.Update;
            Application.Save();

            return NewLocalLicense;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            string NationalNo = clsPeople.GetPersonNationalNoByLocalDrivingLicenseApplicationID(_CurrentLocalDrivingLicenseApplicationID);

            if (!clsDriver.IsDriverExist(NationalNo))
            {
                clsDriver NewDriver = _SetNewDriverInfo();

                if (NewDriver.Save())
                {
                    clsLicense NewLocalLicense = _SetNewLocalLicenseInfo(NewDriver.DriverID);

                    if (NewLocalLicense.Save())
                        MessageBox.Show("Local License Issued Successfully !, License ID is [" + NewLocalLicense.LicenseID + "]", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                        MessageBox.Show("Local License Issue Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                    MessageBox.Show("Adding New Driver Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

            else
            {
                clsLicense NewLocalLicense = _SetNewLocalLicenseInfo(clsDriver.GetDriverIDByNationalNo(NationalNo));

                if (NewLocalLicense.Save())
                    MessageBox.Show("Local License Issued Successfully !, License ID is [" + NewLocalLicense.LicenseID + "]", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                    MessageBox.Show("Local License Issue Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
