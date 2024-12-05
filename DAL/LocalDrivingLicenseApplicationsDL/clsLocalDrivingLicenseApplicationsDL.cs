using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace LocalDrivingLicenseApplicationsDataAccessLayer
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = "Server=TAREQ\\DB1;Database=DVLD;Integrated Security=true;";
    }

    public static class clsLocalDrivingLicenseApplicationsDataAccess
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int GetApplicationIDByLocalDrivingApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select ApplicationID from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    ApplicationID = (int)reader["ApplicationID"];

                }
                else
                {
                    ApplicationID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return ApplicationID;

        }


        public static string GetLocalDrivingLicenseClassByID(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = "";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select ClassName from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    ClassName = (string)reader["ClassName"];

                }
                else
                {
                    ClassName = "";
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return ClassName;

        }

        public static int GetLocalDrivingLicenseIDClassByID(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select LicenseClassID from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    LicenseClassID = (int)reader["LicenseClassID"];

                }
                else
                {
                    LicenseClassID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return LicenseClassID;

        }

        public static int GetLocalDrivingLicenseIDByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select LocalDrivingLicenseApplicationID from LocalDrivingLicenseApplications where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];

                }
                else
                {
                    LocalDrivingLicenseApplicationID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return LocalDrivingLicenseApplicationID;

        }


        public static int GetLocalDrivingLicenseIDByNationalNo(string NationalNo)
        {
            int LocalDrivingLicenseApplicationID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select LocalDrivingLicenseApplicationID from LocalDrivingLicenseApplications_View where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];

                }
                else
                {
                    LocalDrivingLicenseApplicationID = 0;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return LocalDrivingLicenseApplicationID;

        }

        public static string GetFullNameByID(int LocalDrivingLicenseApplicationID)
        {
            string FullName = "";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select FullName from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID =  @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    FullName = (string)reader["FullName"];

                }
                else
                {
                    FullName = "";
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return FullName;

        }
        public static string GetLocalDrivingLicenseStatusByID(int LocalDrivingLicenseApplicationID)
        {
            string Status = "";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select Status from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    Status = (string)reader["Status"];

                }
                else
                {
                    Status = "";
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Status;

        }

        public static int GetLocalDrivingLicensePassedTestsCountByID(int LocalDrivingLicenseApplicationID)
        {
            int PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select PassedTestCount from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    PassedTestCount = (int)reader["PassedTestCount"];

                }
                else
                {
                    PassedTestCount = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return PassedTestCount;

        }

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {

            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications VALUES (@ApplicationID, @LicenseClassID)
        SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine(Error:  + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ID;

        }
        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications
	SET	ApplicationID = @ApplicationID,
	LicenseClassID = @LicenseClassID	WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


            try { connection.Open(); rowsAffected = command.ExecuteNonQuery(); }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);

        }
        public static bool DeleteLocalDrivingLicenseApplication(int ApplicationID,  int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query =
          "Delete LocalDrivingLicenseApplications where  LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID" +
          " Delete Applications where ApplicationID = @ApplicationID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return (rowsAffected > 0);

        }

        public static bool IsLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isFound;

        }

        public static bool IsApplicationClassExist (string ClassName , string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select found = 1 from LocalDrivingLicenseApplications_View where ClassName = @ClassName and NationalNo = @NationalNo and (Status != 'Cancelled')";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isFound;

        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return dt;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications_View()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications_View";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return dt;

        }

        public static int GetNumberOfLocalDrivingLicenseApplications()
        {

            int NumberOfRecords = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT count(*) as NumberOfLocalApplications FROM LocalDrivingLicenseApplications_View";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    NumberOfRecords = (int)reader["NumberOfLocalApplications"];

                }
                else
                {
                    NumberOfRecords = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return NumberOfRecords;
        }


        static string GetQueryFromFilter(string SerachingInfo, string Filter)
        {
            string query = "";
            switch (Filter)
            {

                case "L.D.L AppID":
                    {
                        query = @"   SELECT * FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID LIKE @SerachingInfo";
                        return query;
                    }

                case "National No":
                    {
                        query = @"   SELECT * FROM LocalDrivingLicenseApplications_View WHERE NationalNo LIKE @SerachingInfo";
                        return query;
                    }

                case "Full Name":
                    {
                        query = @"   SELECT * FROM LocalDrivingLicenseApplications_View WHERE FullName LIKE @SerachingInfo";
                        return query;
                    }

                case "Status":
                    {
                        query = @"SELECT * FROM LocalDrivingLicenseApplications_View WHERE Status LIKE @SerachingInfo";
                        return query;
                    }

            }
            return query;
        }

        public static DataTable GetLocalDrivingLicenseApplicationByFilter(string SerachingInfo, string Filter)
        {


            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = GetQueryFromFilter(SerachingInfo, Filter);

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SerachingInfo", "%" + SerachingInfo + "%");

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }


            return dt;
        }


    }


}