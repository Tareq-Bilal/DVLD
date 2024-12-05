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
    public partial class UC_PersonInfoWithFilter : UserControl
    {
        public bool IsUpdateMode ;
        public class clsPersonID
        {
            static public int PersonID { set; get; }

        }
        public UC_PersonInfoWithFilter()
        {
            InitializeComponent();

        }

  
        private void UC_PersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            

            if (IsUpdateMode)
            {
                uC_FindUserByFilter1.Enabled = false;
                uC_PersonInfo1.CurrentPersonID = clsPersonID.PersonID;
                uC_PersonInfo1.LoadPersonInfo();
               
            }

            else
            {
                uC_FindUserByFilter1.DataBack += uC_PersonInfo1.Person_DataBack;
                frmAddPerson.DataBack         += uC_PersonInfo1.Person_DataBack;
                
            }


        }
        
        public void DisableFilter()
        {
            uC_FindUserByFilter1.Enabled = false;
        }

    }
}
