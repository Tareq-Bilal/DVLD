using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTypesBusinessLayer;

namespace DVLD
{
    public partial class frmManageTestTypes : Form
    {
        
        void _LoadTsetTypes()
        {
            dgvTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblNumberOfRecords.Text = clsTestType.GetNumberOfTestTypes().ToString();

            dgvTestTypes.Columns[0].HeaderText = "ID";
            dgvTestTypes.Columns[1].HeaderText = "Title";
            dgvTestTypes.Columns[2].HeaderText = "Description";
            dgvTestTypes.Columns[3].HeaderText = "Test Fees";

        }

        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadTsetTypes();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frmUpdateTestTypes = new frmUpdateTestTypes((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frmUpdateTestTypes.ShowDialog();
        }
    }
}
