using System;
using System.Data;
using LicenseClassesDataAccessLayer;
namespace LicenseClassesBusinessLayer
{

    public class clsLicenseClasse
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }


        public clsLicenseClasse()
        {
            this.LicenseClassID = default;
            this.ClassName = default;
            this.ClassDescription = default;
            this.MinimumAllowedAge = default;
            this.DefaultValidityLength = default;
            this.ClassFees = default;


            Mode = enMode.AddNew;

        }

        private clsLicenseClasse(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;


            Mode = enMode.Update;

        }

        private bool _AddNewLicenseClasse()
        {
            //call DataAccess Layer 

            this.LicenseClassID = clsLicenseClassesDataAccess.AddNewLicenseClasse(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

            return (this.LicenseClassID != -1);

        }

        private bool _UpdateLicenseClasse()
        {
            //call DataAccess Layer 

            return clsLicenseClassesDataAccess.UpdateLicenseClasse(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

        }

        public static clsLicenseClasse Find(int LicenseClassID)
        {
            string ClassName = default;
            string ClassDescription = default;
            byte MinimumAllowedAge = default;
            byte DefaultValidityLength = default;
            decimal ClassFees = default;


            if (clsLicenseClassesDataAccess.GetLicenseClasseInfoByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
                return new clsLicenseClasse(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClasse())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicenseClasse();

            }




            return false;
        }

        public static DataTable GetAllLicenseClasses() { return clsLicenseClassesDataAccess.GetAllLicenseClasses(); }

        public static bool DeleteLicenseClasse(int LicenseClassID) { return clsLicenseClassesDataAccess.DeleteLicenseClasse(LicenseClassID); }

        public static bool isLicenseClasseExist(int LicenseClassID) { return clsLicenseClassesDataAccess.IsLicenseClasseExist(LicenseClassID); }

        public static string GetLicenseClasseNameByID(int LicenseClassID) { return clsLicenseClassesDataAccess.GetLicenseClasseNameByID(LicenseClassID); }

        public static byte GetLicenseClassDefaultValidityLengthByID(int LicenseClassID) { return clsLicenseClassesDataAccess.GetLicenseClassDefaultValidityLengthByID(LicenseClassID); }
        public static decimal GetLicenseClassFeesByID(int LicenseClassID) { return clsLicenseClassesDataAccess.GetLicenseClassFeesByID(LicenseClassID); }

    }

}