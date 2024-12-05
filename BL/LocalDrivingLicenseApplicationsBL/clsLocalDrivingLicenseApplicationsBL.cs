using System;
using System.Data;
using LocalDrivingLicenseApplicationsDataAccessLayer;
namespace LocalDrivingLicenseApplicationsBusinessLayer
{

    public class clsLocalDrivingLicenseApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }


        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = default;
            this.ApplicationID = default;
            this.LicenseClassID = default;


            Mode = enMode.AddNew;

        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;


            Mode = enMode.Update;

        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);

        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            return clsLocalDrivingLicenseApplicationsDataAccess.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);

        }

        public static clsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = default;
            int LicenseClassID = default;


            if (clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();

            }




            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications() { return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications(); }

        public static DataTable GetAllLocalDrivingLicenseApplications_View() { return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications_View(); }
        public static bool DeleteLocalDrivingLicenseApplication(int ApplicationID, int LocalDrivingLicenseApplicationID)
        { return clsLocalDrivingLicenseApplicationsDataAccess.DeleteLocalDrivingLicenseApplication(ApplicationID, LocalDrivingLicenseApplicationID); }

        public static bool isLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID) { return clsLocalDrivingLicenseApplicationsDataAccess.IsLocalDrivingLicenseApplicationExist(LocalDrivingLicenseApplicationID); }

        public static bool IsApplicationClassExist(string ClassName, string NationalNo) { return clsLocalDrivingLicenseApplicationsDataAccess.IsApplicationClassExist(ClassName, NationalNo); }

        public static int GetNumberOfLocalDrivingLicenseApplications() { return clsLocalDrivingLicenseApplicationsDataAccess.GetNumberOfLocalDrivingLicenseApplications(); }

        public static DataTable GetLocalDrivingLicenseApplicationByFilter(string SerachingInfo, string Filter) { return clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicenseApplicationByFilter(SerachingInfo, Filter); }

        public static string GetLocalDrivingLicenseClassByID(int LocalDrivingLicenseApplicationID) { return clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicenseClassByID(LocalDrivingLicenseApplicationID); }
        public static int GetLocalDrivingLicenseIDClassByID(int LocalDrivingLicenseApplicationID) { return clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicenseIDClassByID(LocalDrivingLicenseApplicationID); }
        public static string GetLocalDrivingLicenseStatusByID(int LocalDrivingLicenseApplicationID) { return clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicenseStatusByID(LocalDrivingLicenseApplicationID); }

        public static int GetLocalDrivingLicensePassedTestsCountByID(int LocalDrivingLicenseApplicationID) { return clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicensePassedTestsCountByID(LocalDrivingLicenseApplicationID); }
        public static string GetFullNameByID(int LocalDrivingLicenseApplicationID) { return clsLocalDrivingLicenseApplicationsDataAccess.GetFullNameByID(LocalDrivingLicenseApplicationID); }
        public static int GetApplicationIDByLocalDrivingApplicationID(int LocalDrivingLicenseApplicationID) { return clsLocalDrivingLicenseApplicationsDataAccess.GetApplicationIDByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID); }

        public static int GetLocalDrivingLicenseIDByNationalNo(string NationalNo)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicenseIDByNationalNo(NationalNo);

        }

        public static int GetLocalDrivingLicenseIDByApplicationID(int ApplicationID) 
        { return clsLocalDrivingLicenseApplicationsDataAccess.GetLocalDrivingLicenseIDByApplicationID(ApplicationID); }

    }

}