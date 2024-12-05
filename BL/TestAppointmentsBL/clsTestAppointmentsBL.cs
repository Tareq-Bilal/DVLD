using System;
using System.Data;
using TestAppointmentsDataAccessLayer;
using static TestAppointmentsBusinessLayer.clsTestAppointment;

namespace TestAppointmentsBusinessLayer
{

    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int ? RetakeTestApplicationID { get; set; }


        public struct stTestAppiontmentViewInfo
        {
          //  public int TestID { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public string    Class     { set; get; }
            public string    TestTypeTitle     { set; get; }
            public string    FullName  { set; get; }
            public int       Trails     { set; get; }
            public DateTime  Date     { set; get; }
            public decimal   Fees     { set; get; }
            public bool IsLocked { set; get; }

             public void SetTesAppointmentView(int LocalDrivingLicenseApplicationID, string Class, string TestTypeTitle, string FullName, DateTime Date, decimal Fees, bool IsLocked)
            {
                this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
                this.Class = Class;
                this.FullName = FullName;
                this.Date = Date;
                this.Fees = Fees;
                this.TestTypeTitle = TestTypeTitle;
                this.IsLocked = IsLocked;
            }
        }
        stTestAppiontmentViewInfo _TestAppointmentView;
        public clsTestAppointment()
        {
            this.TestAppointmentID = default;
            this.TestTypeID = default;
            this.LocalDrivingLicenseApplicationID = default;
            this.AppointmentDate = default;
            this.PaidFees = default;
            this.CreatedByUserID = default;
            this.IsLocked = default;
            this.RetakeTestApplicationID = default;

          
            Mode = enMode.AddNew;

        }



        private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;


            Mode = enMode.Update;

        }

        private bool _AddNewTestAppointment()
        {
            //call DataAccess Layer 

            this.TestAppointmentID = clsTestAppointmentsDataAccess.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);

        }

        private bool _UpdateTestAppointment()
        {
            //call DataAccess Layer 

            return clsTestAppointmentsDataAccess.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = default;
            int LocalDrivingLicenseApplicationID = default;
            DateTime AppointmentDate = default;
            decimal PaidFees = default;
            int CreatedByUserID = default;
            bool IsLocked = default;
            int RetakeTestApplicationID = default;


            if (clsTestAppointmentsDataAccess.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }

        public static stTestAppiontmentViewInfo FindViewByTestAppointmentID(int TestAppointmentID)
        {
            string Class = default;
            int LocalDrivingLicenseApplicationID = default;
            string TestTypeTitle = default;
            string FullName = default;
            DateTime Date = default;
            bool IsLocked = default;
            decimal Fees = default;


            if (clsTestAppointmentsDataAccess.GetTestAppointmentViewByTestAppointmentID(TestAppointmentID, ref LocalDrivingLicenseApplicationID, ref Class , ref TestTypeTitle , ref FullName, ref Date, ref Fees, ref IsLocked))
            {
                stTestAppiontmentViewInfo TestAppiontmentViewInfo = new stTestAppiontmentViewInfo();
                TestAppiontmentViewInfo.SetTesAppointmentView(LocalDrivingLicenseApplicationID, Class, TestTypeTitle , FullName ,Date , Fees ,IsLocked);
                return TestAppiontmentViewInfo;
            }

            else
            {
                stTestAppiontmentViewInfo TestAppiontmentViewInfo = new stTestAppiontmentViewInfo();
                TestAppiontmentViewInfo.SetTesAppointmentView(LocalDrivingLicenseApplicationID, Class, TestTypeTitle, FullName, Date, Fees, IsLocked);
                return TestAppiontmentViewInfo;

            }

        }

        public static stTestAppiontmentViewInfo FindViewByLocalApplicationID(int LocalDrivingLicenseApplicationID)
        {
            string Class = default;
            string TestTypeTitle = default;
            string FullName = default;
            DateTime Date = default;
            bool IsLocked = default;
            decimal Fees = default;


            if (clsTestAppointmentsDataAccess.GetTestAppointmentViewByLocalApplicationID(LocalDrivingLicenseApplicationID, ref Class, ref TestTypeTitle, ref FullName, ref Date, ref Fees, ref IsLocked))
            {
                stTestAppiontmentViewInfo TestAppiontmentViewInfo = new stTestAppiontmentViewInfo();
                TestAppiontmentViewInfo.SetTesAppointmentView(LocalDrivingLicenseApplicationID, Class, TestTypeTitle, FullName, Date, Fees, IsLocked);
                return TestAppiontmentViewInfo;
            }

            else
            {
                stTestAppiontmentViewInfo TestAppiontmentViewInfo = new stTestAppiontmentViewInfo();
                TestAppiontmentViewInfo.SetTesAppointmentView(LocalDrivingLicenseApplicationID, Class, TestTypeTitle, FullName, Date, Fees, IsLocked);
                return TestAppiontmentViewInfo;

            }

        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestAppointment();

            }




            return false;
        }

        public static DataTable GetAllTestAppointments() { return clsTestAppointmentsDataAccess.GetAllTestAppointments(); }

        public static bool DeleteTestAppointment(int TestAppointmentID) { return clsTestAppointmentsDataAccess.DeleteTestAppointment(TestAppointmentID); }

        public static bool isTestAppointmentExist(int TestAppointmentID) { return clsTestAppointmentsDataAccess.IsTestAppointmentExist(TestAppointmentID); }

        public static DataTable GetTestAppointmentsForLocalApplication(int TestTypeID, int LocalDrivingLicenseApplicationID)
        { return clsTestAppointmentsDataAccess.GetTestAppointmentsForLocalApplication(TestTypeID , LocalDrivingLicenseApplicationID); }

        public static bool IsApplicationHasAppointments(int LocalDrivingLicenseApplicationID) 
        { return clsTestAppointmentsDataAccess.IsApplicationHasAppointments(LocalDrivingLicenseApplicationID); }

        public static int GetNumberOfTestTrailsForTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        { return clsTestAppointmentsDataAccess.GetNumberOfTestTrailsForTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID); }

        public static bool IsApplicationHasAppointments(int LocalDrivingLicenseApplicationID, int TestTypeID) 
        { return clsTestAppointmentsDataAccess.IsApplicationHasAppointments(LocalDrivingLicenseApplicationID, TestTypeID); }

        public static int IsApplicationHasRetakeTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        { return clsTestAppointmentsDataAccess.IsApplicationHasRetakeTest(LocalDrivingLicenseApplicationID,TestTypeID); }

        public static bool IsTestAppointmentExist(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentsDataAccess.IsTestAppointmentExist(LocalDrivingLicenseApplicationID , TestTypeID);
        }
        public static int IsApplicationHasRetakeTest(int TestAppointmentID) {return clsTestAppointmentsDataAccess.IsApplicationHasRetakeTest (TestAppointmentID); }

        public static int GetTestAppointmentIDByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        { 
            return clsTestAppointmentsDataAccess.GetTestAppointmentIDByLocalDrivingLicenseApplicationID (LocalDrivingLicenseApplicationID);
        }

        public static int GetTheLastRetakeTestID()
        {
            return clsTestAppointmentsDataAccess.GetTheLastRetakeTestID ();
        }

        public static DateTime GetTestAppointmentDate(int TestAppointmentID) { return clsTestAppointmentsDataAccess.GetTestAppointmentDate (TestAppointmentID);}   

    }

}