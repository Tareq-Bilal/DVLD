using System;
using System.Data;
using ApplicationTypesDataAccessLayer;
namespace ApplicationTypesBusinessLayer
{

    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }


        public clsApplicationType()
        {
            this.ApplicationTypeID = default;
            this.ApplicationTypeTitle = default;
            this.ApplicationFees = default;


            Mode = enMode.AddNew;

        }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;


            Mode = enMode.Update;

        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = clsApplicationTypesDataAccess.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);

            return (this.ApplicationTypeID != -1);

        }

        private bool _UpdateApplicationType()
        {
            //call DataAccess Layer 

            return clsApplicationTypesDataAccess.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);

        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = default;
            decimal ApplicationFees = default;


            if (clsApplicationTypesDataAccess.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }




            return false;
        }

        public static DataTable GetAllApplicationTypes() { return clsApplicationTypesDataAccess.GetAllApplicationTypes(); }
        public static bool DeleteApplicationType(int ApplicationTypeID) { return clsApplicationTypesDataAccess.DeleteApplicationType(ApplicationTypeID); }
        public static bool isApplicationTypeExist(int ApplicationTypeID) { return clsApplicationTypesDataAccess.IsApplicationTypeExist(ApplicationTypeID); }
        public static int GetNumberOfApplicationTypes() { return clsApplicationTypesDataAccess.GetNumberOfApplicationTypes(); }
        public static decimal GetApplicationFeesByID(int ApplicationTypeID) { return clsApplicationTypesDataAccess.GetApplicationFeesByID(ApplicationTypeID); }
        public static string GetApplicationTypeNameByID(int ApplicationTypeID) { return clsApplicationTypesDataAccess.GetApplicationTypeNameByID(ApplicationTypeID); }



    }

}