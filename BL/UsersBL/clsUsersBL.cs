using System;
using System.Data;
using UsersDataAccessLayer;
namespace UsersBusinessLayer
{

    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }


        public clsUser()
        {
            this.UserID = default;
            this.PersonID = default;
            this.UserName = default;
            this.Password = default;
            this.IsActive = default;


            Mode = enMode.AddNew;

        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;


            Mode = enMode.Update;

        }

        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUsersDataAccess.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);

        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUsersDataAccess.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);

        }

        public static clsUser Find(int UserID)
        {
            int PersonID = default;
            string UserName = default;
            string Password = default;
            bool IsActive = default;


            if (clsUsersDataAccess.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;

        }

        public static clsUser Find(string UserName)
        {
            int PersonID = default;
            int UserID = default;
            string Password = default;
            bool IsActive = default;


            if (clsUsersDataAccess.GetUserInfoByUserName(UserName, ref UserID , ref PersonID, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;

        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }




            return false;
        }

        public static DataTable GetAllUsers() { return clsUsersDataAccess.GetAllUsers(); }

        public static bool DeleteUser(int UserID) { return clsUsersDataAccess.DeleteUser(UserID); }

        public static bool isUserExist(int UserID) { return clsUsersDataAccess.IsUserExist(UserID); }

        public static bool IsUserExistByPersonID(int PersonID) { return clsUsersDataAccess.IsUserExistByPersonID(PersonID); }
        public static bool IsUserExist(string UserName) { return clsUsersDataAccess.IsUserExist(UserName); }

        public static int GetNumberOfUsers() { return clsUsersDataAccess.GetNumberOfUsers(); }

        public static DataTable GetUserByFilter(string SerachingInfo, string Filter) { return clsUsersDataAccess.GetUserByFilter(SerachingInfo, Filter); }

        public static int GetUserIDByPersonID(int PersonID) { return clsUsersDataAccess.GetUserIDByPersonID(PersonID); }

        public static int GetPersonIDByUserID(int UserID) { return clsUsersDataAccess.GetPersonIDByUserID(UserID); }

        public static string GetUserNameByID(int UserID) { return clsUsersDataAccess.GetUserNameByID(UserID); }
    }

}