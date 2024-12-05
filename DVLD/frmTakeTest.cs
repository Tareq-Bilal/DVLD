using ApplicationsBusinessLayer;
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
using static TestAppointmentsBusinessLayer.clsTestAppointment;

namespace DVLD
{
    public partial class frmTakeTest : Form
    {
        int _CurrentTestAppointment = 0;
        clsTestAppointment.stTestAppiontmentViewInfo stTestAppiontmentViewInfo = new stTestAppiontmentViewInfo();
        public frmTakeTest(int TestAppointmentID , bool IsLocked)
        {
            InitializeComponent();
            
            _CurrentTestAppointment = TestAppointmentID;
            uC_TestInfo1.Set(TestAppointmentID);
            LoadTestByStatus(IsLocked);
        }

        void LoadTestByStatus(bool IsLocked)
        {

            if (IsLocked)
            {
                
                rbFail.Enabled = rbPass.Enabled = false;
                lblNotice.Visible = true;
                btnSave.Enabled = false;
            }


        }

        clsTest _SetTestInfo()
        {
            clsTest Test = new clsTest();

            if (rbPass.Checked)
                Test.TestResult = true;

            else
                Test.TestResult = false;

            Test.Notes = tbNotes.Text;
            Test.TestAppointmentID = _CurrentTestAppointment;
            Test.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            Test.Mode = clsTest.enMode.AddNew;
        
            return Test;
        }
        private void btnSave_Click(object sender, EventArgs e)
            {
   

            DialogResult = MessageBox.Show("Are You Sure To Save Test Result ? , After that you cannot change the result", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(DialogResult == DialogResult.Yes)
            {
                clsTestAppointment TestAppointment = clsTestAppointment.Find(_CurrentTestAppointment);
                TestAppointment.IsLocked = true;
                TestAppointment.Mode = clsTestAppointment.enMode.Update;

                if (clsTestAppointment.IsApplicationHasRetakeTest(_CurrentTestAppointment) == -1)
                    TestAppointment.RetakeTestApplicationID = null;

                if (TestAppointment.Save())
                    {
                        clsTest Test = _SetTestInfo();
                        if (Test.Save())
                            MessageBox.Show("Data Saved Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else
                            MessageBox.Show("Data Saved Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            
        }
    }
}
