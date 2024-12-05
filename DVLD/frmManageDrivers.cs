using DriversBusinessLayer;
using InternationalLicensesBusinessLayer;
using LocalDrivingLicenseApplicationsBusinessLayer;
using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        void _LoadDriversData()
        {
            cbFilter.SelectedIndex = 0;
            dgvDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDrivers.DataSource          = clsDriver.GetAllDrivers_View();
            lblNumberOfRecords.Text        = clsDriver.GetNumberOfDrivers().ToString();

        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadDriversData();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                tbSearch.Visible = false;
                _LoadDriversData();
            }

            else tbSearch.Visible = true;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchingInfo = tbSearch.Text.Trim();

            dgvDrivers.DataSource = clsDriver.GetDriverByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvDrivers.CurrentRow.Cells[2].Value;
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(NationalNo);
            frmShowPersonLicensesHistory.ShowDialog();

        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmPersonInfo frmPersonInfo = new frmPersonInfo((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frmPersonInfo.ShowDialog();

        }

        private void issueInternationalINFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvDrivers.CurrentRow.Cells[0].Value;

            if (clsInternationalLicense.GetInternationalLicenseIDByDriverID(DriverID) == -1)
            {
                frmAddInternationalLicense frmAddInternationalLicense = new frmAddInternationalLicense();
                frmAddInternationalLicense.ShowDialog();
            }

            else
                MessageBox.Show("Driver Already Has An International License !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
