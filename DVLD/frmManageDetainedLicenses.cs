using DetainedLicensesBusinessLayer;
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
using UsersBusinessLayer;

namespace DVLD
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();

            UC_DeatinLicense.DataBack += DetainLicense_DataBack;
            UC_ReleaseDetainedLicenses.DataBack += DetainLicense_DataBack;
        }

        public void DetainLicense_DataBack(object sender, bool DetainCompleted)
        {
            if (DetainCompleted) _LoadDeatinedLicenses();
        }
        public void ReleaseLicense_DataBack(object sender, bool ReleaseCompleted)
        {
            if (ReleaseCompleted) _LoadDeatinedLicenses();
        }

        void _LoadDeatinedLicenses()
        {
            dgvDeatinedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeatinedLicenses.DataSource = clsDetainedLicense.GetAllDetainedLicenses();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _LoadDeatinedLicenses();
            cbIsReleased.Visible = false;
            lblNumberOfRecords.Text = dgvDeatinedLicenses.RowCount.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "None")
            {
                tbSearch.Visible = false;
                cbIsReleased.Visible = false;
                _LoadDeatinedLicenses();
            }

            else if (cbFilter.SelectedItem.ToString() == "Is Released")
            {
                // loaction : 
                tbSearch.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Location = new Point(303, 242);


            }

            else
            {
                tbSearch.Visible = true;
                cbIsReleased.Visible = false;

            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SearchingInfo;

            if (cbIsReleased.SelectedItem.ToString() == "Yes")
                SearchingInfo = "1";

            else if (cbIsReleased.SelectedItem.ToString() == "No")
                SearchingInfo = "0";

            else
                SearchingInfo = "ALL";


            dgvDeatinedLicenses.DataSource = clsDetainedLicense.GetDeatinedLicensesByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchingInfo = tbSearch.Text.Trim();

            dgvDeatinedLicenses.DataSource = clsDetainedLicense.GetDeatinedLicensesByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPeople.GetPersonIDByNationalNo((string)dgvDeatinedLicenses.CurrentRow.Cells[6].Value);
            frmPersonInfo frmPersonInfo = new frmPersonInfo(PersonID);
            frmPersonInfo.ShowDialog();
        }

        private void ShowLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDeatinedLicenses.CurrentRow.Cells[1].Value;
            frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(LicenseID);
            frmDriverLicenseInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvDeatinedLicenses.CurrentRow.Cells[6].Value;
            frmShowPersonLicensesHistory frmShowPersonLicensesHistory = new frmShowPersonLicensesHistory(NationalNo);
            frmShowPersonLicensesHistory.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();
            frmDetainLicense.ShowDialog();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            bool IsReleased = (bool)dgvDeatinedLicenses.CurrentRow.Cells[3].Value;
        
            if(IsReleased) releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            else           releaseDetainedLicenseToolStripMenuItem.Enabled = true ;



        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DetainID = (int)dgvDeatinedLicenses.CurrentRow.Cells[0].Value;
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense(DetainID);
            frmReleaseDetainedLicense.ShowDialog();
        }
    }
}
