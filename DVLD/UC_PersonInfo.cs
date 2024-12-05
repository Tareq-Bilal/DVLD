using CountriesBusinessLayer;
using PeopleBusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class UC_PersonInfo : UserControl
    {
        clsPeople _CurrentPerson = new clsPeople();
        public int CurrentPersonID = 0;
        string EmptyField = "-----";
        
        public UC_PersonInfo()
        {
            InitializeComponent();



        }

       void EmptyAllFields()
        {

          lblPersonID.Text    = EmptyField;
          lblName.Text        = EmptyField;
          lblNationalNo.Text  = EmptyField;
          lblEmail.Text       = EmptyField;
          lblGender.Text      = EmptyField;
          lblAddress.Text     = EmptyField;
          lblDateOfBirth.Text = EmptyField;
          lblCountry.Text     = EmptyField;
          lblPhone.Text       = EmptyField;
          pbPersonImage.Load(@"D:\TAREQ\Course 19 - Full Real Project\Icons\Icons\Male 512.png");
          linkLabelEditInfo.Visible = false;
        }
        public void LoadPersonInfo()
        {
  
             _CurrentPerson = clsPeople.Find(CurrentPersonID);

            if(_CurrentPerson != null)
            {

                lblPersonID.Text = _CurrentPerson.PersonID.ToString();
                lblName.Text = _CurrentPerson.FirstName + " " + _CurrentPerson.SecondName + " " + _CurrentPerson.ThirdName + " " + _CurrentPerson.LastName;
                lblNationalNo.Text = _CurrentPerson.NationalNo.ToString();

                if (_CurrentPerson.Email != null)
                    lblEmail.Text = _CurrentPerson.Email.ToString();

                else
                    lblEmail.Text = "---";

                lblPhone.Text = _CurrentPerson.Phone.ToString();

                if (_CurrentPerson.Gendor == 0)
                    lblGender.Text = "Male";

                else
                    lblGender.Text = "Female";

                lblAddress.Text = _CurrentPerson.Address.ToString();
                lblDateOfBirth.Text = _CurrentPerson.DateOfBirth.ToString("d");
                lblCountry.Text = clsCountry.GetCountryNameByID(_CurrentPerson.NationalityCountryID);
                pbPersonImage.Load(_CurrentPerson.ImagePath);
                linkLabelEditInfo.Visible = true;
            }

            else
            {
                linkLabelEditInfo.Visible = false;
                MessageBox.Show("Person Does Not Found !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Person_DataBack(object sender, int PersonID)
        {
            if(PersonID != -1) {

                CurrentPersonID = PersonID;
                LoadPersonInfo();
                linkLabelEditInfo.Visible = true;

            }

            else
                EmptyAllFields();
        }

        private void UC_PersonInfo_Load_1(object sender, EventArgs e)
        {
            //   LoadPersonInfo();

            linkLabelEditInfo.Visible = false;

        }


        private void linkLabelEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPerson frmAddPerson = new frmAddPerson(_CurrentPerson.PersonID);
            frmAddPerson.ShowDialog();
        }

        private void linkLabelEditInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPerson frmAddPerson = new frmAddPerson(CurrentPersonID); frmAddPerson.ShowDialog();
        }
    }
}
