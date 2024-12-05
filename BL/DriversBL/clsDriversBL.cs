using System;
using System.Data;
using DriversDataAccessLayer;
namespace DriversBusinessLayer
{

    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }


        public clsDriver()
        {
            this.DriverID = default;
            this.PersonID = default;
            this.CreatedByUserID = default;
            this.CreatedDate = default;


            Mode = enMode.AddNew;

        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;


            Mode = enMode.Update;

        }

        private bool _AddNewDriver()
        {
            //call DataAccess Layer 

            this.DriverID = clsDriversDataAccess.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID != -1);

        }

        private bool _UpdateDriver()
        {
            //call DataAccess Layer 

            return clsDriversDataAccess.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);

        }

        public static clsDriver Find(int DriverID)
        {
            int PersonID = default;
            int CreatedByUserID = default;
            DateTime CreatedDate = default;


            if (clsDriversDataAccess.GetDriverInfoByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDriver();

            }




            return false;
        }

        public static DataTable GetAllDrivers() { return clsDriversDataAccess.GetAllDrivers(); }
        public static DataTable GetAllDrivers_View() { return clsDriversDataAccess.GetAllDrivers_View(); }
        public static bool DeleteDriver(int DriverID) { return clsDriversDataAccess.DeleteDriver(DriverID); }
        public static bool isDriverExist(int DriverID) { return clsDriversDataAccess.IsDriverExist(DriverID); }
        public static DataTable GetDriverByFilter(string SerachingInfo, string Filter) { return clsDriversDataAccess.GetDriverByFilter(SerachingInfo, Filter); }
        public static int GetNumberOfDrivers() { return clsDriversDataAccess.GetNumberOfDrivers(); }
        public static int GetPersonIDByDriverID(int DriverID) { return clsDriversDataAccess.GetPersonIDByDriverID(DriverID); }
        public static string GetFullNameByDriverID(int DriverID) { return clsDriversDataAccess.GetFullNameByDriverID(DriverID); }
        public static bool IsDriverExist(string NationalNo) { return clsDriversDataAccess.IsDriverExist(NationalNo);  }
        public static int GetDriverIDByNationalNo(string NationalNo) { return clsDriversDataAccess.GetDriverIDByNationalNo(NationalNo); }
        public static DataTable GetDriverLocalLicenses(int DriverID) { return clsDriversDataAccess.GetDriverLocalLicenses(DriverID); }
        public static DataTable GetDriverInternationalLicenses(int DriverID) { return clsDriversDataAccess.GetDriverInternationalLicenses(DriverID); }
        public static int GetDriverIDByLicenseID(int LicenseID) { return clsDriversDataAccess.GetDriverIDByLicenseID(LicenseID); }
        public static string GetNationalNoByDriverID(int DriverID) { return clsDriversDataAccess.GetNationalNoByDriverID(DriverID);  }

    }

}