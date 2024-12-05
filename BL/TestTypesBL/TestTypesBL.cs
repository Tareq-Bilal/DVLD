using System;
using System.Data;
using TestTypesDataAccessLayer;
namespace TestTypesBusinessLayer
{

    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int TestTypesID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }


        public clsTestType()
        {
            this.TestTypesID = default;
            this.TestTypeTitle = default;
            this.TestTypeDescription = default;
            this.TestTypeFees = default;


            Mode = enMode.AddNew;

        }

        private clsTestType(int TestTypesID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypesID = TestTypesID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;


            Mode = enMode.Update;

        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.TestTypesID = clsTestTypesDataAccess.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypesID != -1);

        }

        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypesDataAccess.UpdateTestType(this.TestTypesID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

        }

        public static clsTestType Find(int TestTypesID)
        {
            string TestTypeTitle = default;
            string TestTypeDescription = default;
            decimal TestTypeFees = default;


            if (clsTestTypesDataAccess.GetTestTypeInfoByID(TestTypesID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
                return new clsTestType(TestTypesID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }




            return false;
        }

        public static DataTable GetAllTestTypes() { return clsTestTypesDataAccess.GetAllTestTypes(); }

        public static bool DeleteTestType(int TestTypesID) { return clsTestTypesDataAccess.DeleteTestType(TestTypesID); }

        public static bool isTestTypeExist(int TestTypesID) { return clsTestTypesDataAccess.IsTestTypeExist(TestTypesID); }

        public static int GetNumberOfTestTypes() { return clsTestTypesDataAccess.GetNumberOfTestTypes(); }

        public static decimal GetTestTypeFeeByID(int TestTypeID) { return clsTestTypesDataAccess.GetTestTypeFeeByID(TestTypeID); }

    }

}