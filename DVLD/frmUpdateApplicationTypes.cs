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
    public partial class frmUpdateApplicationTypes : Form
    {
        clsApplicationType _CurrentApplicatonType = new clsApplicationType();
        public frmUpdateApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();

            _CurrentApplicatonType = clsApplicationType.Find(ApplicationTypeID);

        }

        void _LoadApplicationTypeData()
        {
            lblApplicationTypeID.Text = _CurrentApplicatonType.ApplicationTypeID.ToString();
            tbTitle.Text              = _CurrentApplicatonType.ApplicationTypeTitle.ToString();
            tbFees.Text               = _CurrentApplicatonType.ApplicationFees.ToString();
        }

        void _SetApplicationTypeData()
        {
            _CurrentApplicatonType.ApplicationTypeTitle = tbTitle.Text;
            _CurrentApplicatonType.ApplicationFees = decimal.Parse(tbFees.Text);
            _CurrentApplicatonType.Mode = clsApplicationType.enMode.Update;
        }

        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypeData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SetApplicationTypeData();

            if (_CurrentApplicatonType.Save())
                MessageBox.Show("Data Svaed Successfully !" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information);

            else
                MessageBox.Show("Data Svaing Failed !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
    }
}
