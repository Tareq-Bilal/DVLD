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
    public partial class frmAddEditAppointment : Form
    {

        public frmAddEditAppointment(int ID , int TestType  = -1)
        {
            InitializeComponent();

            if (clsTestAppointment.isTestAppointmentExist(ID))
                uC_AddEditAppointment1.SetByTestAppointmentID(ID);

            else
                uC_AddEditAppointment1.SetByLocalApplicationID(ID , TestType);

        }
    }
}
