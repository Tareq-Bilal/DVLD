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

namespace DVLD
{
    public partial class frmTestAppintments : Form
    {
        enum enTestType  { enVisionTest = 1 , enWrittenTest , enStreetTest };
        
        int _CurrnetLocalDrivingLicenseApplicationID = 0;
        enTestType _CurrentTestType;
        public frmTestAppintments(int TestTypeID , int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _CurrnetLocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            uC_LocalDrivingLicenseApploicationInfo1.Set(LocalDrivingLicenseApplicationID);
            _CurrentTestType = (enTestType)TestTypeID;
        }

        void _SetTitleAndPicture()
        {
            switch (_CurrentTestType)
            {
                
                case enTestType.enVisionTest:
                    {
                        lblTetsAppointmentType.Text = "Vision  Test  Appointments";
                        pbTestTypePicture.Load(@"D:\\TAREQ\\Course 19 - Full Real Project\\Icons\\Icons\\Vision 512.png");
                        break;
                    }

                case enTestType.enWrittenTest:
                    {
                        lblTetsAppointmentType.Text = "Written  Test  Appointments";
                        pbTestTypePicture.Load(@"D:\\TAREQ\\Course 19 - Full Real Project\\Icons\\Icons\\Written Test 512.png");
                        break;
                    }

                case enTestType.enStreetTest:
                    {
                        lblTetsAppointmentType.Text = "Street  Test  Appointments";
                        pbTestTypePicture.Load(@"D:\\TAREQ\\Course 19 - Full Real Project\\Icons\\Icons\\driving-test 512.png");
                        break;
                    }
            }

        }
        public void LoadTestAppintmentsInfo()
        {
            _SetTitleAndPicture();
            dgvTestAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTestAppointments.DataSource = clsTestAppointment.GetTestAppointmentsForLocalApplication((int)_CurrentTestType , _CurrnetLocalDrivingLicenseApplicationID);
            if(dgvTestAppointments.RowCount > 0 )
                dgvTestAppointments.Columns[1].Visible = dgvTestAppointments.Columns[2].Visible = dgvTestAppointments.Columns[5].Visible = dgvTestAppointments.Columns[7].Visible = false;
            
            lblNumberOfRecords.Text = dgvTestAppointments.RowCount.ToString();
        }
        private void frmTestAppintments_Load(object sender, EventArgs e)
        {
            LoadTestAppintmentsInfo();
        }

        private void btnAddTestAppintment_Click(object sender, EventArgs e)
        {
            if (!clsTestAppointment.IsTestAppointmentExist(_CurrnetLocalDrivingLicenseApplicationID, (int)_CurrentTestType)){
                frmAddEditAppointment frmAddEditAppointment = new frmAddEditAppointment(_CurrnetLocalDrivingLicenseApplicationID, (int)_CurrentTestType);
                frmAddEditAppointment.ShowDialog();
            }
      
            else
                MessageBox.Show("Person already has active appointments for this test, You cannot add new appointment", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DateTime TestAppointmentDate = clsTestAppointment.GetTestAppointmentDate((int)dgvTestAppointments.CurrentRow.Cells[0].Value);
            if (DateTime.Compare(TestAppointmentDate , DateTime.Today) == 0)
            {
                int TestAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;
                bool IsLocked = (bool)dgvTestAppointments.CurrentRow.Cells[6].Value;
                frmTakeTest frmTakeTest = new frmTakeTest(TestAppointmentID, IsLocked);
                frmTakeTest.ShowDialog();

            }

            else
                MessageBox.Show("Test Appointment Does Not Match, Your Test Musty Be On ["+ TestAppointmentDate +"], Please Book New Appointment !!" , "",MessageBoxButtons.OK , MessageBoxIcon.Error);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;
            frmAddEditAppointment frmAddEditAppointment = new frmAddEditAppointment(TestAppointmentID , (int)_CurrentTestType);
            frmAddEditAppointment.ShowDialog();
        }
    }
}
