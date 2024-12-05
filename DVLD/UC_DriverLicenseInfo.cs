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

namespace DVLD
{
    public partial class UC_DriverLicenseInfo : UserControl
    {
        clsLicense _CurrentLicense = new clsLicense();
       // public int LicenseID = 0;
        public UC_DriverLicenseInfo()
        {
            InitializeComponent();


        }

        public void SetDriverLicenseInfo(int LicenseID)
        {
            _LoadLicenseData(LicenseID);
        }
        void _LoadLicenseData(int LicenseID)
        {
            _CurrentLicense = clsLicense.Find(LicenseID);

            if (_CurrentLicense == null)
                return;

            clsPeople Person     = clsPeople.Find(clsDriver.GetPersonIDByDriverID(_CurrentLicense.DriverID));
            lblLicenseID.Text    = _CurrentLicense.LicenseID.ToString();
            lblDriverID.Text     = _CurrentLicense.DriverID.ToString();
            lblLicenseClass.Text = clsLicenseClasse.GetLicenseClasseNameByID(_CurrentLicense.LicenseClass);
            lblIssueDate.Text    = _CurrentLicense.IssueDate.ToString();
            lblIssueReason.Text  = clsApplicationType.GetApplicationTypeNameByID(_CurrentLicense.IssueReason);
            lblDateOfBirth.Text  = Person.DateOfBirth.ToShortDateString();
            lblExpDate.Text      = _CurrentLicense.ExpirationDate.ToShortDateString();
            lblName.Text         = clsDriver.GetFullNameByDriverID(_CurrentLicense.DriverID);
            lblNationalNo.Text   = Person.NationalNo.ToString();

           if(string.IsNullOrEmpty(_CurrentLicense.Notes))
                lblNotes.Text = "No Notes";

            else
                lblNotes.Text = _CurrentLicense.Notes;

            if (Person.Gendor == 0)
                lblGender.Text = "Male";

            else
                lblGender.Text = "Female";


            if (_CurrentLicense.IsActive)
                lblIsActive.Text = "Yes";

            else
                lblIsActive.Text = "No";

            if (clsLicense.IsLicenseDetained(_CurrentLicense.LicenseID))
                lblIsDetained.Text = "Yes";

            else
                lblIsDetained.Text = "No";

            pbPersonImage.Load(Person.ImagePath);

        }

      
        private void UC_DriverLicenseInfo_Load(object sender, EventArgs e)
        {
        
        }
    }
}
