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
using TestTypesBusinessLayer;

namespace DVLD
{
    public partial class frmUpdateTestTypes : Form
    {
        clsTestType _CurrentTestType = new clsTestType();
        public frmUpdateTestTypes(int TestTypeID)
        {
            InitializeComponent();

            _CurrentTestType = clsTestType.Find(TestTypeID);

        }
        void _LoadTsetTypeData()
        {

            lblTestTypeID.Text = _CurrentTestType.TestTypesID.ToString();
            tbTitle.Text       = _CurrentTestType.TestTypeTitle.ToString();
            tbDescription.Text = _CurrentTestType.TestTypeDescription.ToString();
            tbFees.Text        = _CurrentTestType.TestTypeFees.ToString();
        }

        void _SetTsetTypeData()
        {
            _CurrentTestType.TestTypeTitle       = tbTitle.Text;
            _CurrentTestType.TestTypeDescription = tbDescription.Text;
            _CurrentTestType.TestTypeFees        = decimal.Parse(tbFees.Text);
            _CurrentTestType.Mode                = clsTestType.enMode.Update;
        }



        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _LoadTsetTypeData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SetTsetTypeData();
            
            if(_CurrentTestType.Save())
                MessageBox.Show("Data Svaed Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("Data Svaing Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
