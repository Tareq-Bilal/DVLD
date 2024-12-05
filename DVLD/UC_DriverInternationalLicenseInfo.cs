using DriversBusinessLayer;
using InternationalLicensesBusinessLayer;
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
    public partial class UC_DriverInternationalLicenseInfo : UserControl
    {
        public UC_DriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void SetInternationalDriverLicenseInfo(int IntLicenseID)
        {
            clsInternationalLicense InternationalLicense = clsInternationalLicense.Find(IntLicenseID);

            clsPeople Person = clsPeople.Find(clsDriver.GetPersonIDByDriverID(InternationalLicense.DriverID));

            lblIntLicID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            lblIssueDate.Text = InternationalLicense.IssueDate.ToShortDateString();
            lblExpDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();
            lblDriverID.Text = InternationalLicense.DriverID.ToString();
            lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
            lblName.Text = clsPeople.GetPersonFullNameByID(Person.PersonID);
            lblNationalNo.Text = Person.NationalNo.ToString();
            
            if (Person.Gendor == 0)
                lblGender.Text = "Male";

            else
                lblGender.Text = "Female";

            if (InternationalLicense.IsActive)
                lblIsActive.Text = "Yes";

            else
                lblIsActive.Text = "No";

            pbPersonImage.Load(Person.ImagePath);
        }

        private void UC_DriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
