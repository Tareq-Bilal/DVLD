using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;

namespace TestAppointmentsDataAccessLayer
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = "Server=TAREQ\\DB1;Database=DVLD;Integrated Security=true;";
    }

    public static class clsTestAppointmentsDataAccess
    {
        public static bool GetTestAppointmentInfoByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value ? (int)reader["RetakeTestApplicationID"] : RetakeTestApplicationID = default;

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

        public static bool GetTestAppointmentViewByTestAppointmentID(int TestAppointmentID, ref int LocalDrivingLicenseApplicationID, ref string Class, ref string TestTypeTitle , ref string FullName , ref DateTime Date, ref decimal Fees , ref bool IsLocked)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from TestAppointments_View where TestAppointmentID =  @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    Class = (string)reader["ClassName"];
                    Date = (DateTime)reader["AppointmentDate"];
                    FullName = (string)reader["FullName"];
                    Fees = (decimal)reader["PaidFees"];
                    IsLocked = (bool)reader["IsLocked"];

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

        public static bool GetTestAppointmentViewByLocalApplicationID(int LocalDrivingLicenseApplicationID , ref string Class, ref string TestTypeTitle, ref string FullName, ref DateTime Date, ref decimal Fees, ref bool IsLocked)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from TestAppointments_View where LocalDrivingLicenseApplicationID =  @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    Class = (string)reader["ClassName"];
                    Date = (DateTime)reader["AppointmentDate"];
                    FullName = (string)reader["FullName"];
                    Fees = (decimal)reader["PaidFees"];
                    IsLocked = (bool)reader["IsLocked"];

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
        public static int GetTestAppointmentIDByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int TestAppointmentID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select TestAppointmentID from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    TestAppointmentID = (int)reader["TestAppointmentID"];

                }
                else
                {
                    TestAppointmentID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return TestAppointmentID;

        }


        public static int GetNumberOfTestTrailsForTestAppointment( int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int Trails = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select COUNT(*)as Trails from TestAppointments  where TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    Trails = (int)reader["Trails"];

                }
                else
                {
                    Trails = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Trails;

        }


        public static DataTable GetTestAppointmentsForLocalApplication(int TestTypeID ,int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from TestAppointments where  LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int ? RetakeTestApplicationID)
        {

            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID)
        SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (string.IsNullOrEmpty(RetakeTestApplicationID.ToString()))
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

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
        //public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int? RetakeTestApplicationID)
        //{
        //    int rowsAffected = 0;

        //    // Using 'using' statements to ensure proper resource management
        //    using (SqlConnection connection = new SqlConnection("Server=TAREQ\\DB1;Database=DVLD;Integrated Security=true;"))
        //    using (SqlCommand command = new SqlCommand(@"UPDATE TestAppointments
        //SET TestTypeID = @TestTypeID,
        //    LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
        //    AppointmentDate = @AppointmentDate,
        //    PaidFees = @PaidFees,
        //    CreatedByUserID = @CreatedByUserID,
        //    IsLocked = @IsLocked,
        //    RetakeTestApplicationID = @RetakeTestApplicationID
        //WHERE TestAppointmentID = @TestAppointmentID", connection))
        //    {
        //        // Adding parameters
        //        command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
        //        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
        //        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
        //        command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
        //        command.Parameters.AddWithValue("@PaidFees", PaidFees);
        //        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
        //        command.Parameters.AddWithValue("@IsLocked", IsLocked);

        //        // Handling nullable RetakeTestApplicationID
        //        if (RetakeTestApplicationID.HasValue)
        //            command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID.Value);
        //        else
        //            command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

        //        try
        //        {
        //            connection.Open();
        //            rowsAffected = command.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle the exception (log it, rethrow it, etc.)
        //            // Optionally, return false or rethrow the exception based on how you want to handle it
        //        }
        //    }

        //    return (rowsAffected > 0);
        //}

        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int ? RetakeTestApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestAppointments
	SET	TestTypeID = @TestTypeID,
	LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
	AppointmentDate = @AppointmentDate,
	PaidFees = @PaidFees,
	CreatedByUserID = @CreatedByUserID,
	IsLocked = @IsLocked,
	RetakeTestApplicationID = @RetakeTestApplicationID	WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (string.IsNullOrEmpty(RetakeTestApplicationID.ToString()))
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            try { connection.Open(); rowsAffected = command.ExecuteNonQuery(); }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);

        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return (rowsAffected > 0);

        }

        public static bool IsTestAppointmentExist(int TestAppointmentID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM TestAppointments WHERE TestAppointmentID= @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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


        public static bool IsTestAppointmentExist(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select found = 1 from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID" +
                "  and TestTypeID = @TestTypeID and IsLocked = 0";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        public static bool IsApplicationHasAppointments(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select found = 1 from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
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

        public static bool IsApplicationHasAppointments(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select found = 1 from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
        //	
        public static int IsApplicationHasRetakeTest(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {
            int RetakeTestApplicationID = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //  string query = "select RetakeTestApplicationID from TestAppointments where TestAppointmentID = @TestAppointmentID and RetakeTestApplicationID is not null";

            string query = "	SELECT ISNULL((SELECT TOP 1 RetakeTestApplicationID FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID AND RetakeTestApplicationID IS NOT NULL), -1) AS RetakeTestApplicationID;";
            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                }
                else
                {
                    RetakeTestApplicationID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return RetakeTestApplicationID;

        }

        public static int IsApplicationHasRetakeTest(int TestAppointmentID)
        {
            int RetakeTestApplicationID = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //  string query = "select RetakeTestApplicationID from TestAppointments where TestAppointmentID = @TestAppointmentID and RetakeTestApplicationID is not null";

            string query = "	SELECT ISNULL((SELECT TOP 1 RetakeTestApplicationID FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID  AND RetakeTestApplicationID IS NOT NULL), -1) AS RetakeTestApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                }
                else
                {
                    RetakeTestApplicationID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return RetakeTestApplicationID;

        }

        public static int GetTheLastRetakeTestID()
        {
            int RetakeTestApplicationID = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //  string query = "select RetakeTestApplicationID from TestAppointments where TestAppointmentID = @TestAppointmentID and RetakeTestApplicationID is not null";

            // string query = "SELECT TOP  1 RetakeTestApplicationID from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID order by RetakeTestApplicationID desc";

            string query = "select top 1 RetakeTestApplicationID from TestAppointments order by RetakeTestApplicationID desc";

            SqlCommand command = new SqlCommand(query, connection);

            //command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                }
                else
                {
                    RetakeTestApplicationID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return RetakeTestApplicationID;

        }

        public static DateTime GetTestAppointmentDate (int TestAppointmentID)
        {
            DateTime AppointmentDate = DateTime.Now;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select AppointmentDate from TestAppointments where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                }
                else
                {
                    AppointmentDate = DateTime.MinValue;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return AppointmentDate;

        }
        public static DataTable GetAllTestAppointments()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM TestAppointments";
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




    }

}