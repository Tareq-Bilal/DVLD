using DriversBusinessLayer;
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

namespace DVLD
{
    public partial class frmShowPersonLicensesHistory : Form
    {

        void _LoadPersonWithFilterInfo(string NationalNo)
        {
            uC_PersonInfoWithFilter1.IsUpdateMode = true;
            UC_PersonInfoWithFilter.clsPersonID.PersonID = clsPeople.GetPersonIDByNationalNo(NationalNo);
            uC_PersonInfoWithFilter1.DisableFilter();
        }
        void _LoadPersonLicensesHistoryInfo(string NationalNo) { uC_PersonLicensesHistory1.SetDriverID(clsDriver.GetDriverIDByNationalNo(NationalNo)); }
        public frmShowPersonLicensesHistory(string NationalNo)
        {
            InitializeComponent();

            _LoadPersonWithFilterInfo(NationalNo);
            _LoadPersonLicensesHistoryInfo(NationalNo);

        }

        private void frmShowPersonLicensesHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
