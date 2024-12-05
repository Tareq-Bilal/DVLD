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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusinessLayer;

namespace DVLD
{
    public partial class frmManageInternationalLicenses : Form
    {
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }

        void _LoadInternatoinalDrivingApplicatoins()
        {
            dgvInternationalApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInternationalApplications.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
            lblNumberOfRecords.Text = dgvInternationalApplications.RowCount.ToString();
           
            dgvInternationalApplications.Columns["CreatedByUserID"].Visible = false;
            cbFilter.SelectedIndex = 0;
            cbIsActive.Visible = false;

        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                tbSearch.Visible = false;
                cbIsActive.Visible = false;
                _LoadInternatoinalDrivingApplicatoins();
            }

            else if (cbFilter.SelectedItem.ToString() == "Is Active")
            {

                tbSearch.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Location = new Point(304, 262);


            }

            else
            {
                tbSearch.Visible = true;
                cbIsActive.Visible = false;

            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchingInfo = tbSearch.Text.Trim();

            dgvInternationalApplications.DataSource = clsInternationalLicense.GetInternationalDrivingLicenseApplicationByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SearchingInfo;

            if (cbIsActive.SelectedItem.ToString() == "Yes")
                SearchingInfo = "1";

            else if (cbIsActive.SelectedItem.ToString() == "No")
                SearchingInfo = "0";

            else
                SearchingInfo = "ALL";


            dgvInternationalApplications.DataSource = clsInternationalLicense.GetInternationalDrivingLicenseApplicationByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());
        }

        private void btnAddNewInternationalApplication_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicense frmAddInternationalLicense = new frmAddInternationalLicense();
            frmAddInternationalLicense.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalApplications.CurrentRow.Cells[2].Value;
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(clsDriver.GetNationalNoByDriverID(DriverID));
            frmShowPersonLicensesHistory.ShowDialog();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalApplications.CurrentRow.Cells[2].Value;
            int PersonID = clsPeople.GetPersonIDByNationalNo(clsDriver.GetNationalNoByDriverID(DriverID));
            frmPersonInfo frmPersonInfo = new frmPersonInfo(PersonID);
            frmPersonInfo.ShowDialog();
        }

        private void ShowIntLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int IntLicenseID = (int)dgvInternationalApplications.CurrentRow.Cells[0].Value;
            frmInternationalDriverLicenseInfo frmInternationalDriverLicenseInfo = new frmInternationalDriverLicenseInfo(IntLicenseID);
            frmInternationalDriverLicenseInfo.ShowDialog();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _LoadInternatoinalDrivingApplicatoins();
        }


    }
}
