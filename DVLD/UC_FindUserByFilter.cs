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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class UC_FindUserByFilter : UserControl
    {
        clsPeople _CurrentPerson = new clsPeople();
        public int CurrrentPersonID;
        public UC_FindUserByFilter()
        {
            InitializeComponent();
        }


        public delegate void DataBackEventHandler(object sender, int PerosnID);

        public event DataBackEventHandler DataBack;
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "Person ID" &&  !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If it's not a control key or a digit, suppress the key press
                e.Handled = true;
            }
        }

        private void btnSearcPerson_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "Person ID")
            {
                if (clsPeople.isPeopleExist(int.Parse(tbSearch.Text)))
                {
                    epIsFound.SetError(tbSearch, "");
                    CurrrentPersonID = int.Parse(tbSearch.Text);
                    _CurrentPerson = clsPeople.Find(CurrrentPersonID);
                    DataBack?.Invoke(this , CurrrentPersonID);
                    clsPersonSelected.IsPersonSelected = true;
                    clsPersonSelected.PersonID = CurrrentPersonID;
                   UC_PersonInfoWithFilter.clsPersonID.PersonID = CurrrentPersonID;
                }


                else
                {
                    tbSearch.Select(0, tbSearch.Text.Length);
                    epIsFound.SetError(tbSearch, "Person ID Does Not Exist !");
                    DataBack?.Invoke(this, -1);
                    clsPersonSelected.IsPersonSelected = false;


                }
            }

            else
            {
                _CurrentPerson = clsPeople.Find(tbSearch.Text);

                if (_CurrentPerson != null)
                {
                    epIsFound.SetError(tbSearch, "");
                    CurrrentPersonID = _CurrentPerson.PersonID;
                    DataBack?.Invoke(this, CurrrentPersonID);
                    clsPersonSelected.IsPersonSelected = true;
                    clsPersonSelected.PersonID = CurrrentPersonID;
                    UC_PersonInfoWithFilter.clsPersonID.PersonID = _CurrentPerson.PersonID;

                }

                else
                { 
                    tbSearch.Select(0, tbSearch.Text.Length);
                    epIsFound.SetError(tbSearch, "National Number Does Not Exist !");
                    DataBack?.Invoke(this, -1);
                    clsPersonSelected.IsPersonSelected = false;

                }

            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frmAddPerson = new frmAddPerson();
            frmAddPerson.ShowDialog();
        }

        private void UC_FindUserByFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }
    }
}
