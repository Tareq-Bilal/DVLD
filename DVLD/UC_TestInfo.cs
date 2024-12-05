using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAppointmentsBusinessLayer;
using TestsBusinessLayer;
using static TestAppointmentsBusinessLayer.clsTestAppointment;

namespace DVLD
{
    public partial class UC_TestInfo : UserControl
    {
        clsTestAppointment.stTestAppiontmentViewInfo TestAppiontmentViewInfo;
        public UC_TestInfo()
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

        public void Set(int TestAppointmentID)
        {
            TestAppiontmentViewInfo =  clsTestAppointment.FindViewByTestAppointmentID(TestAppointmentID);
            int TestTypeID = GetTestTypeID(TestAppiontmentViewInfo.TestTypeTitle);
            _SetTitleAndPicture(TestTypeID);

            lblLocalApplicationID.Text = TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text              = TestAppiontmentViewInfo.Class;
            lblName.Text               = TestAppiontmentViewInfo.FullName;
            lblDate.Text               = TestAppiontmentViewInfo.Date.ToShortDateString();
            lblFees.Text               = TestAppiontmentViewInfo.Fees.ToString("00");
            gpScheduleTest.Text        = TestAppiontmentViewInfo.TestTypeTitle;
            lblTrail.Text              = clsTestAppointment.GetNumberOfTestTrailsForTestAppointment(TestAppiontmentViewInfo.LocalDrivingLicenseApplicationID, TestTypeID).ToString();

            int TestID = clsTest.IsTestAppointmentTaken(TestAppointmentID);
            if (TestID != -1) lblTestID.Text = TestID.ToString();


        }

        private void UC_TestInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
