using DriversBusinessLayer;
using InternationalLicensesBusinessLayer;
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

namespace DVLD
{
    public partial class UC_PersonLicensesHistory : UserControl
    {
        int _CurrentDriverID = 0;
        bool IsLocaldgvSelected = true;
        public UC_PersonLicensesHistory()
        {
            InitializeComponent();
        }

        void _HideLocalColumns()
        {
            dgvLocalLicenses.Columns[2].Visible = dgvLocalLicenses.Columns[6].Visible = dgvLocalLicenses.Columns[7].Visible
                = dgvLocalLicenses.Columns[9].Visible = dgvLocalLicenses.Columns[10].Visible = false;
           
        }

        #region LoadData
        void _LoadLocalDriverLicenses()
        {
            dgvLocalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLocalLicenses.DataSource = clsDriver.GetDriverLocalLicenses(_CurrentDriverID);
            lblNumberOfRecords.Text = dgvLocalLicenses.RowCount.ToString();

        }
        void _LoadInternationalDriverLicenses()
        {
            dgvInternationalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvInternationalLicenses.DataSource = clsDriver.GetDriverInternationalLicenses(_CurrentDriverID);
            lblNumberOfRecordsInter.Text = dgvInternationalLicenses.RowCount.ToString();



        }
        #endregion
        public void SetDriverID(int DriverID) { _CurrentDriverID = DriverID; }

        private void tpLocal_Enter(object sender, EventArgs e) { _LoadLocalDriverLicenses(); _HideLocalColumns(); IsLocaldgvSelected = true; }

        private void tpInternationalLicenses_Enter(object sender, EventArgs e) 
        { _LoadInternationalDriverLicenses(); IsLocaldgvSelected = false;  }
        private void UC_PersonLicensesHistory_Load(object sender, EventArgs e)
        {
            _LoadLocalDriverLicenses();
            _LoadInternationalDriverLicenses();
            _HideLocalColumns();

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsLocaldgvSelected)
            {
                int LicenseID = (int)dgvLocalLicenses.CurrentRow.Cells[0].Value;
                frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(LicenseID);
                frmDriverLicenseInfo.ShowDialog();
            }

            else
            {
                int IntLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
                frmInternationalDriverLicenseInfo frmDriverLicenseInfo = new frmInternationalDriverLicenseInfo(IntLicenseID);
                frmDriverLicenseInfo.ShowDialog();
            }


        }

        private string _GetClassName(int ClassID)
        {
            string ClassName = "";

            switch (ClassID)
            {
                case 1:
                    ClassName = "Class 1 - Small Motorcycle";
                    break;

                case 2:
                    ClassName = "Class 2 - Heavy Motorcycle License";
                    break;

                case 3:
                    ClassName = "Class 3 - Ordinary driving license";
                    break;

                case 4:
                    ClassName = "Class 4 - Commercial";
                    break;

                case 5:
                    ClassName = "Class 5 - Agricultural";
                    break;

                case 6:
                    ClassName = "Class 6 - Small and medium bus";
                    break;

                case 7:
                    ClassName = "Class 7 - Truck and heavy vehicle";
                    break;
            }

            return ClassName;
        }

        private void dgvLocalLicenses_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            const int targetColumnIndex = 3;

            if (e.ColumnIndex == targetColumnIndex && e.RowIndex >= 0)
            {
                e.Value = _GetClassName(int.Parse(e.Value.ToString()));
                e.FormattingApplied = true;
            }
        }
    }
}
