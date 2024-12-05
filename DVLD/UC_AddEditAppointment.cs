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
using TestAppointmentsBusinessLayer;
using TestsBusinessLayer;
using TestTypesBusinessLayer;
using UsersBusinessLayer;

namespace DVLD
{
    public partial class UC_AddEditAppointment : UserControl
    {

        int _CurrentTestAppointmentID = 0;
        clsTestAppointment.stTestAppiontmentViewInfo TestAppiontmentViewInfo;
        enum enMode { enAddAppointment = 1 , enEdit , enAddNewAppointmentFirstTime }
        enMode _CurrentMode;
        int _CurrentTestTypeID = 0;
        public UC_AddEditAppointment()
        {
            InitializeComponent();

        }

        int GetTestTypeID(string TestTypeTitle)
        {
            int TestTypeID = 0;
            switch (TestTypeTitle)
            {

                case "Vision Test":
                    TestTypeID = 1;
                    break;

                case "Written (Theory) Test":
                    TestTypeID = 2;
                    break;

                case "Practical (Street) Test":
                    TestTypeID = 3;
                    break;


            }

            return TestTypeID;

        }

        void _SetTitleAndPicture(int TestTypeID)
        {
            switch (TestTypeID)
            {

                case 1:
                    {
                        pbTestTypePicture.Load(@"D:\\TAREQ\\Course 19 - Full Real Project\\Icons\\Icons\\Vision 512.png");
                        break;
                    }

                case 2:
                    {
                        pbTestTypePicture.Load(@"D:\\TAREQ\\Course 19 - Full Real Project\\Icons\\Icons\\Written Test 512.png");
                        break;
                    }

                case 3:
                    {
                        pbTestTypePicture.Load(@"D:\\TAREQ\\Course 19 - Full Real Project\\Icons\\Icons\\driving-test 512.png");
                        break;
                    }
            }

        }

        void _LoadAppointmentInfo() {

            int TestTypeID = GetTestTypeID(TestAppiontmentViewInfo.TestTypeTitle);
            _SetTitleAndPicture(TestTypeID);

            lblLocalApplicationID.Text = TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = TestAppiontmentViewInfo.Class;
            lblName.Text = TestAppiontmentViewInfo.FullName;
            lblFees.Text = TestAppiontmentViewInfo.Fees.ToString("00");
            gpScheduleTest.Text = TestAppiontmentViewInfo.TestTypeTitle;

            

            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.CustomFormat = "d/M/yyyy";

            if(_CurrentMode == enMode.enEdit)
            {
                dtpAppointmentDate.Text = TestAppiontmentViewInfo.Date.ToString();
                lblTrail.Text = clsTestAppointment.GetNumberOfTestTrailsForTestAppointment(TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID, TestTypeID).ToString();
            }

            else
            {
                dtpAppointmentDate.Text = DateTime.Today.ToString();
                lblTrail.Text = "0";
                gbRetakeTestInfo.Enabled = false;
            }


            int RetakeTestID = clsTestAppointment.IsApplicationHasRetakeTest(_CurrentTestAppointmentID);
            if (RetakeTestID == -1)
                gbRetakeTestInfo.Enabled = false;

            else
            {
                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestAppID.Text = RetakeTestID.ToString();
                lblRetakeAppFees.Text = clsApplicationType.GetApplicationFeesByID(7).ToString("00");
                lblTotalFees.Text = (clsApplicationType.GetApplicationFeesByID(7) + TestAppiontmentViewInfo.Fees).ToString("00.0");
            }

        }
        void _LoadNonLockedAppointment()
        {
            _LoadAppointmentInfo();
        }
  
        void _LoadLockedAppointment()
        {

            _LoadAppointmentInfo();
            dtpAppointmentDate.Enabled = false;
            btnSave.Enabled = false;
            lblNotice.Visible = true;
            lblNotice.Text = "Person alredy sat for this test, appointment locked";

        }
        public void SetByTestAppointmentID(int TestAppointmentID)
        {


            _CurrentTestAppointmentID = TestAppointmentID;
              TestAppiontmentViewInfo = clsTestAppointment.FindViewByTestAppointmentID(TestAppointmentID);
                _CurrentMode = enMode.enEdit;

                if (!TestAppiontmentViewInfo.IsLocked)
                    _LoadNonLockedAppointment();

                else
                    _LoadLockedAppointment();

        }

        void _LoadNewAppointmentInfo(int LocalDrivingLicenseApplicationID , int TestType)
        {
            lblLocalApplicationID.Text = LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseClassByID(LocalDrivingLicenseApplicationID);
            lblFees.Text = clsTestType.GetTestTypeFeeByID(TestType).ToString("00");
            lblName.Text = clsLocalDrivingLicenseApplication.GetFullNameByID(LocalDrivingLicenseApplicationID).ToString();
            _SetTitleAndPicture(TestType);
            lblRetakeAppFees.Text = clsApplicationType.GetApplicationFeesByID(7).ToString("00");
            lblTotalFees.Text = (clsApplicationType.GetApplicationFeesByID(7) + clsTestType.GetTestTypeFeeByID(TestType)).ToString("00.0");

            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.CustomFormat = "d/M/yyyy";
            dtpAppointmentDate.Text = DateTime.Today.ToString();
            int NumberOfTrails = clsTestAppointment.GetNumberOfTestTrailsForTestAppointment(TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID, TestType);
            lblTrail.Text = NumberOfTrails.ToString();

            if (NumberOfTrails == 0) _CurrentMode = enMode.enAddNewAppointmentFirstTime;

            else                     _CurrentMode = enMode.enAddAppointment;

            gbRetakeTestInfo.Enabled = true;
        }
        public void SetByLocalApplicationID(int LocalDrivingLicenseApplicationID , int TestType)
        {

            _CurrentTestTypeID = TestType;
            TestAppiontmentViewInfo = clsTestAppointment.FindViewByLocalApplicationID(LocalDrivingLicenseApplicationID);

                if (!clsTestAppointment.IsTestAppointmentExist(TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID, _CurrentTestTypeID))
                    _LoadNewAppointmentInfo(LocalDrivingLicenseApplicationID, _CurrentTestTypeID);

                else
                    MessageBox.Show("Person already has active appointments for this test, You cannot add new appointment", "", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }
        clsTestAppointment _SetNewTestAppointmentInfo()
        {

            clsTestAppointment NewTestAppointment = new clsTestAppointment();

            NewTestAppointment.TestTypeID = _CurrentTestTypeID;
            NewTestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            NewTestAppointment.LocalDrivingLicenseApplicationID = TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID;
            NewTestAppointment.PaidFees = clsTestType.GetTestTypeFeeByID(_CurrentTestTypeID);
            NewTestAppointment.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            NewTestAppointment.IsLocked = false;
            NewTestAppointment.Mode = clsTestAppointment.enMode.AddNew;

          //  int RetakeID = clsTestAppointment.GetTheLastRetakeTestID();
          //  NewTestAppointment.RetakeTestApplicationID = ++RetakeID ;

            return NewTestAppointment;
        }

        clsTestAppointment _SetNewTestAppointmentFirstTimeInfo()
        {

            clsTestAppointment NewTestAppointment = new clsTestAppointment();

            NewTestAppointment.TestTypeID = _CurrentTestTypeID;
            NewTestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            NewTestAppointment.LocalDrivingLicenseApplicationID = int.Parse(lblLocalApplicationID.Text);
            NewTestAppointment.PaidFees = decimal.Parse(lblFees.Text);
            NewTestAppointment.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            NewTestAppointment.IsLocked = false;
            NewTestAppointment.Mode = clsTestAppointment.enMode.AddNew;
            NewTestAppointment.RetakeTestApplicationID = null;

            return NewTestAppointment;
        }

        clsApplication _SetApplicationInfo()
        {

            clsApplication NewApplication = new clsApplication();
            string NationalNo = clsPeople.GetPersonNationalNoByLocalDrivingLicenseApplicationID(TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID);

            NewApplication.ApplicantPersonID = clsPeople.GetPersonIDByNationalNo(NationalNo);
            NewApplication.ApplicationStatus = 1;

            if(clsTestAppointment.IsApplicationHasRetakeTest(TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID , _CurrentTestTypeID) == -1)
            {
                NewApplication.ApplicationDate = DateTime.Today;
                NewApplication.ApplicationTypeID = 1;

            }

            else
            {
                NewApplication.ApplicationDate = TestAppiontmentViewInfo.Date;
                NewApplication.ApplicationTypeID = 7;

            }

            NewApplication.LastStatusDate    = dtpAppointmentDate.Value;
            NewApplication.PaidFees          = decimal.Parse(lblFees.Text);
            NewApplication.CreatedByUserID   = clsCurrentUser.CurrentUser.UserID;
            NewApplication.Mode              = clsApplication.enMode.AddNew;

            return NewApplication;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_CurrentMode == enMode.enEdit)
            {
                clsTestAppointment TestAppointment = clsTestAppointment.Find(_CurrentTestAppointmentID);
                TestAppointment.AppointmentDate = dtpAppointmentDate.Value;

                if (TestAppointment.RetakeTestApplicationID == null || TestAppointment.RetakeTestApplicationID == 0)
                    TestAppointment.RetakeTestApplicationID = null;

                if (TestAppointment.Save())
                    MessageBox.Show("Data Saved Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                    MessageBox.Show("Data Saving Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else if (_CurrentMode == enMode.enAddNewAppointmentFirstTime)
            {
                clsApplication NewApplication = _SetApplicationInfo();

                if (NewApplication.Save())
                {
                    clsTestAppointment NewTestAppointment = _SetNewTestAppointmentFirstTimeInfo();

                    if (NewTestAppointment.Save())
                    {
                        MessageBox.Show("Appointment Added Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                        MessageBox.Show("Appointment Adding Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
     

            } 

            else
            {
                clsApplication NewApplication         = _SetApplicationInfo();

                if (NewApplication.Save())
                {
                    clsTestAppointment NewTestAppointment = _SetNewTestAppointmentInfo();
                    NewTestAppointment.RetakeTestApplicationID = NewApplication.ApplicationID;

                    if (NewTestAppointment.Save())
                        MessageBox.Show("Appointment Added Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                        MessageBox.Show("Appointment Adding Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
    }
}
