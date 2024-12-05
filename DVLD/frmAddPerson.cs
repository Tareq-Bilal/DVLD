using CountriesBusinessLayer;
using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddPerson : Form
    {
        clsPeople _CurrentPerosn = new clsPeople();
        clsPeople.enMode _CurrentMode;
        string selectedFilePath = null;

        public delegate void DataBackEventHandler(object sender, int PerosnID);

        public static event DataBackEventHandler DataBack;

        public frmAddPerson(int PersonID = - 1)
        {
            InitializeComponent();

            if (PersonID != -1)
            {
                _CurrentMode = clsPeople.enMode.Update;
                _CurrentPerosn = clsPeople.Find(PersonID);

            }


            else
            {
                _CurrentMode = clsPeople.enMode.AddNew;
                _CurrentPerosn.Mode = clsPeople.enMode.AddNew;

            }

        }

        void _SetMinimumDateOfBirth()
        {
            DateTime Today = DateTime.Now;

            dtpDateOfBirth.MaxDate = Today.AddYears(-18);

        }

        private bool IsNumeric(string value)
        {
            double result;
            return double.TryParse(value, out result);
        }

        private bool AreAllTextBoxesFilled()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                }

                // Recursively check nested controls
                if (control.HasChildren)
                {
                    if (!AreNestedTextBoxesFilled(control))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool AreNestedTextBoxesFilled(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is TextBox textBox )
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return false;
                    }
                }

                // Recursively check nested controls
                if (control.HasChildren)
                {
                    if (!AreNestedTextBoxesFilled(control))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool _AreControlsValid()
        {
            return AreAllTextBoxesFilled();
            
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Load(@"D:\TAREQ\Course 19 - Full Real Project\Icons\Icons\Male 512.png");

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Load(@"D:\TAREQ\Course 19 - Full Real Project\Icons\Icons\Female 512.png");

        }

        private void frmAddPerson_Load(object sender, EventArgs e)
        {
            cbCountry.SelectedItem = "Jordan";

            if (_CurrentMode == clsPeople.enMode.AddNew)
            {
                _SetMinimumDateOfBirth();
                linkLabelRemovePicture.Visible = false;
                
            }

            else
            {
                lblTitle.Text = "Update Person Info";
                linkLabelRemovePicture.Visible = true;
                _LoadPersonInfo();
                _SetMinimumDateOfBirth();


            }

        }

        void _LoadPersonInfo()
        {
            lblPersonID.Text     = _CurrentPerosn.PersonID.ToString();
            tbNationalNo.Text    = _CurrentPerosn.NationalNo;
            tbFirsName.Text      = _CurrentPerosn.FirstName;
            tbSecondName.Text    = _CurrentPerosn.SecondName;
            tbThirdName.Text     = _CurrentPerosn.ThirdName;
            tbLastName.Text      = _CurrentPerosn.LastName;
            tbEmail.Text         = _CurrentPerosn.Email;
            tbAddress.Text       = _CurrentPerosn.Address;
            tbPhone.Text         = _CurrentPerosn.Phone;
            dtpDateOfBirth.Value = _CurrentPerosn.DateOfBirth;
            
            if(_CurrentPerosn.Gendor == 0)
                rbMale.Checked = true;

            else
                rbFemale.Checked = true;

            pbPersonImage.Load(_CurrentPerosn.ImagePath);
            selectedFilePath = _CurrentPerosn.ImagePath;
            cbCountry.SelectedIndex = (_CurrentPerosn.NationalityCountryID);
            _CurrentPerosn.Mode = clsPeople.enMode.Update;
        }

        void _SetPersonInfo()
        {

            _CurrentPerosn.NationalNo  = tbNationalNo.Text;
            _CurrentPerosn.FirstName   = tbFirsName.Text;
            _CurrentPerosn.SecondName  = tbSecondName.Text;
            _CurrentPerosn.ThirdName   = tbThirdName.Text;
            _CurrentPerosn.LastName    = tbLastName.Text;
            _CurrentPerosn.Email       = tbEmail.Text;
            _CurrentPerosn.Address     = tbAddress.Text;
            _CurrentPerosn.Phone       = tbPhone.Text;
            _CurrentPerosn.DateOfBirth = dtpDateOfBirth.Value;

            if (rbFemale.Checked)
                _CurrentPerosn.Gendor = 1;

            else
                _CurrentPerosn.Gendor = 0;

            if (_CurrentPerosn.ImagePath == null && _CurrentPerosn.Gendor == 0)
                _CurrentPerosn.ImagePath = @"D:\TAREQ\Course 19 - Full Real Project\Icons\Icons\Male 512.png";

            else if (_CurrentPerosn.ImagePath == null && _CurrentPerosn.Gendor == 1)
                _CurrentPerosn.ImagePath = @"D:\TAREQ\Course 19 - Full Real Project\Icons\Icons\Female 512.png";

            else
                _CurrentPerosn.ImagePath = selectedFilePath;


            _CurrentPerosn.NationalityCountryID = clsCountry.GetCountryIDByName(cbCountry.SelectedItem.ToString());

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AreControlsValid() == false)
            {
                MessageBox.Show("Please Fill All Fields","",MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }

            _SetPersonInfo();
            if (_CurrentPerosn.Save())
            {
                clsPersonSelected.IsPersonSelected = true;
                UC_PersonInfoWithFilter.clsPersonID.PersonID = _CurrentPerosn.PersonID;
                DataBack?.Invoke(this, _CurrentPerosn.PersonID);
                MessageBox.Show("Data Saved Successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblPersonID.Text = _CurrentPerosn.PersonID.ToString();
               
            }

            else
            {
                MessageBox.Show("Failed To Save Data !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (string.IsNullOrEmpty(textBox.Text))
                epEmailFormat.SetError(textBox, "");

            // Regular expression pattern for validating an email address


               else if (!Regex.IsMatch(textBox.Text, emailPattern)) {

                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);
                epEmailFormat.SetError(textBox, "Please enter a Valid Email Format.");
            }

        }

        private void tbNationalNo_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            epNumericValidation.SetError(textBox, "");
        }
        private void linkLabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog1.FileName;
                _CurrentPerosn.ImagePath = selectedFilePath;
                pbPersonImage.Load(selectedFilePath);
            }
        }

        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
                epNumericValidation.SetError(textBox, "");

           else if (clsPeople.IsNationalNumberExist(textBox.Text))
            {
                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);
                epUnipueNationalNoValidation.SetError(textBox, "National Number Is Already Exist !");
            }

            else if (!clsPeople.IsNationalNumberExist(textBox.Text))
                epUnipueNationalNoValidation.SetError(textBox, "");

        }

        private void tbPhone_Validating_1(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text))
                epNumericValidation.SetError(textBox, "");

            else if (!IsNumeric(textBox.Text))
            {
                e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);
                epNumericValidation.SetError(textBox, "Please enter a valid numeric value.");
            }
        }

        private void linkLabelRemovePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            _CurrentPerosn.ImagePath = null;
        }
    }
}
