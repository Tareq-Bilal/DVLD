using System;
using System.Data;
using PeopleDataAccessLayer;
namespace PeopleBusinessLayer
{

    public class clsPeople
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }


        public clsPeople()
        {
            this.PersonID = default;
            this.NationalNo = default;
            this.FirstName = default;
            this.SecondName = default;
            this.ThirdName = default;
            this.LastName = default;
            this.DateOfBirth = default;
            this.Gendor = default;
            this.Address = default;
            this.Phone = default;
            this.Email = default;
            this.NationalityCountryID = default;
            this.ImagePath = default;


            Mode = enMode.AddNew;

        }

        private clsPeople(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;


            Mode = enMode.Update;

        }

        private bool _AddNewPeople()
        {
            //call DataAccess Layer 

            this.PersonID = clsPeopleDataAccess.AddNewPeople(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);

        }

        private bool _UpdatePeople()
        {
            //call DataAccess Layer 

            return clsPeopleDataAccess.UpdatePeople(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

        }

        public static clsPeople Find(int PersonID)
        {
            string NationalNo = default;
            string FirstName = default;
            string SecondName = default;
            string ThirdName = default;
            string LastName = default;
            DateTime DateOfBirth = default;
            byte Gendor = default;
            string Address = default;
            string Phone = default;
            string Email = default;
            int NationalityCountryID = default;
            string ImagePath = default;


            if (clsPeopleDataAccess.GetPeopleInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;

        }

        public static clsPeople Find(string NationalNo)
        {
            int PersonID = default;
            string FirstName = default;
            string SecondName = default;
            string ThirdName = default;
            string LastName = default;
            DateTime DateOfBirth = default;
            byte Gendor = default;
            string Address = default;
            string Phone = default;
            string Email = default;
            int NationalityCountryID = default;
            string ImagePath = default;


            if (clsPeopleDataAccess.GetPeopleInfoByNationalNo(NationalNo , ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPeople())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePeople();

            }




            return false;
        }

        public static DataTable GetAllPeople() { return clsPeopleDataAccess.GetAllPeople(); }

        public static bool DeletePeople(int PersonID) { return clsPeopleDataAccess.DeletePeople(PersonID); }

        public static bool isPeopleExist(int PersonID) { return clsPeopleDataAccess.IsPeopleExist(PersonID); }

        public static int GetNumberOfPeople() { return clsPeopleDataAccess.GetNumberOfPeople(); }

        public static DataTable GetPeopleByFilter(string SerachingInfo, string Filter)
        {

            return clsPeopleDataAccess.GetPeopleByFilter(SerachingInfo , Filter);

        }

        public static bool IsNationalNumberExist(string NationalNo)
        {
            return clsPeopleDataAccess.IsNationalNumberExist(NationalNo);
        }

        public static bool IsPersonHasRealtionsInSystem(int ApplicantPersonID) 
        {
            return clsPeopleDataAccess.IsPersonHasRealtionsInSystem(ApplicantPersonID);
        }

        public static int GetPersonIDByNationalNo(string NationalNo) { return clsPeopleDataAccess.GetPersonIDByNationalNo (NationalNo); }

        public static string GetPersonNationalNoByID(int PersonID) { return clsPeopleDataAccess.GetPersonNationalNoByID (PersonID); }

        public static string GetPersonFullNameByID(int PersonID) { return clsPeopleDataAccess.GetPersonFullNameByID(PersonID); }

        public static string GetPersonNationalNoByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return clsPeopleDataAccess.GetPersonNationalNoByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
        }
    }

}