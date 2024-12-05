using ApplicationTypesBusinessLayer;
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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        void _LoadApplicationTypes()
        {
            dgvApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvApplicationTypes.DataSource = clsApplicationType.GetAllApplicationTypes();
            lblNumberOfRecords.Text = clsApplicationType.GetNumberOfApplicationTypes().ToString();
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypes();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationTypes frmUpdateApplicationTypes = new frmUpdateApplicationTypes((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frmUpdateApplicationTypes.ShowDialog();
        }
    }
}
