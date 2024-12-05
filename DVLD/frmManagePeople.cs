using CountriesBusinessLayer;
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
    public partial class frmManagePeople : Form
    {
        int PersonID = 0;
        public frmManagePeople()
        {
            InitializeComponent();
        }

       
        public void _LoadPeople()
        {
            dgvPeople.DataSource = clsPeople.GetAllPeople();

            dgvPeople.Columns[12].Visible = false;
            dgvPeople.Columns[8].Visible = false;
            dgvPeople.Columns[11].HeaderText = "Nationality";

            lblNumberOfRecords.Text = clsPeople.GetNumberOfPeople().ToString();

        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            tbSearch.Visible = false;
            _LoadPeople();

        }

        private void dgvPeople_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            short targetColumnIndex = 7;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                // Check if the current cell is in the target column and a data cell
                if (e.ColumnIndex == targetColumnIndex && e.ColumnIndex < dgvPeople.Columns.Count && e.RowIndex < dgvPeople.Rows.Count)
                {
                    // ... (rest of formatting logic remains the same)
                    // Get the value, check if < 0, set red foreground color if applicable
                    short cellValue;
                    if (short.TryParse(e.Value?.ToString(), out cellValue))
                    {
                        if (cellValue == 0)
                            e.Value = "Male";

                        else
                            e.Value = "Female";

                    }
                }
            }

            short targetColumnIndex2 = 11;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                // Check if the current cell is in the target column and a data cell
                if (e.ColumnIndex == targetColumnIndex2 && e.ColumnIndex < dgvPeople.Columns.Count && e.RowIndex < dgvPeople.Rows.Count)
                {
                    // ... (rest of formatting logic remains the same)
                    // Get the value, check if < 0, set red foreground color if applicable
                    short cellValue;
                    if (short.TryParse(e.Value?.ToString(), out cellValue))
                    {

                        e.Value = clsCountry.GetCountryNameByID(cellValue);

                    }
                }
            }


        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedItem.ToString() == "None")
            {
                tbSearch.Visible = false;
                _LoadPeople();
            }

            else tbSearch.Visible = true;

        }
        private bool IsNumeric(string value)
        {
            double result;
            return double.TryParse(value, out result);
        }
        private void tbSearch_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
                epSearchInputValidation.SetError(textBox, "");

          else if ( (cbFilter.SelectedItem.ToString() == "Person ID" || cbFilter.SelectedItem.ToString() == "National No." || cbFilter.SelectedItem.ToString() == "Phone") & !IsNumeric(textBox.Text))
            {
                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);
                epSearchInputValidation.SetError(textBox, "Please enter a valid numeric value.");
            }



        }

        private void tbSearch_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            epSearchInputValidation.SetError(textBox, "");
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string SearchingInfo = tbSearch.Text.Trim();

            dgvPeople.DataSource = clsPeople.GetPeopleByFilter(SearchingInfo, cbFilter.SelectedItem.ToString());

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddPerson frmAddPerson = new frmAddPerson();
            frmAddPerson.ShowDialog();
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddPerson frmAddPerson = new frmAddPerson();
            frmAddPerson.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnted Yet !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            MessageBox.Show("Not Implemnted Yet !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
           frmPersonInfo frmPersonInfo = new frmPersonInfo(PersonID);
            frmPersonInfo.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            if (!clsPeople.IsPersonHasRealtionsInSystem(PersonID))
            {
                DialogResult result = MessageBox.Show("Are You Sure To Delete Person With ID [ " + PersonID + " ] ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (clsPeople.DeletePeople(PersonID))
                    {

                        MessageBox.Show("Person With ID [ " + PersonID + " ] Deleted Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _LoadPeople();

                    }
                }
            }
        
        
            else
               MessageBox.Show("Delete Fiald !! , Person Has Relations In The System !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmAddPerson frmAddPerson = new frmAddPerson(PersonID);
            frmAddPerson.ShowDialog();
        }
    }
}
