using System;
using System.Data;
using System.Data.SqlClient;

namespace PeopleDataAccessLayer
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = "Server=TAREQ\\DB1;Database=DVLD;Integrated Security=true;";
    }

    public static class clsPeopleDataAccess
    {
        public static bool GetPeopleInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : ThirdName = default;
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = reader["Gendor"] != DBNull.Value ? (byte)reader["Gendor"] : (byte)0;
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : Email = default;
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : ImagePath = default;

                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetPeopleInfoByNationalNo(string NationalNo , ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : ThirdName = default;
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = reader["Gendor"] != DBNull.Value ? (byte)reader["Gendor"] : (byte)0;
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : Email = default;
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : ImagePath = default;

                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return isFound;

        }

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select PersonID from People where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    PersonID = (int)reader["PersonID"];


                }
                else
                {
                    PersonID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return PersonID;

        }

        public static string GetPersonNationalNoByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            string NationalNo = "";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select NationalNo from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    NationalNo = (string)reader["NationalNo"];


                }
                else
                {
                    NationalNo = "";
                }

                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return NationalNo;

        }


        public static string GetPersonNationalNoByID(int PersonID)
        {
            string NationalNo = "";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select NationalNo from People where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    NationalNo = (string)reader["NationalNo"];


                }
                else
                {
                    NationalNo = "";
                }

                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return NationalNo;

        }

        public static string GetPersonFullNameByID(int PersonID)
        {
            string FullName = "";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select FirstName + ' ' +  SecondName + ' ' + ThirdName + ' ' + LastName as FullName from People where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

#pragma warning disable CS0168 // Variable is declared but never used
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
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return FullName;

        }

        public static int AddNewPeople(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {

            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
        SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            command.Parameters.AddWithValue("@FirstName", FirstName);

            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);

            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gendor", Gendor);

            command.Parameters.AddWithValue("@Address", Address);

            command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

#pragma warning disable CS0168 // Variable is declared but never used
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
#pragma warning restore CS0168 // Variable is declared but never used


            return ID;

        }
        public static bool UpdatePeople(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE People
	SET	NationalNo = @NationalNo,
	FirstName = @FirstName,
	SecondName = @SecondName,
	ThirdName = @ThirdName,
	LastName = @LastName,
	DateOfBirth = @DateOfBirth,
	Gendor = @Gendor,
	Address = @Address,
	Phone = @Phone,
	Email = @Email,
	NationalityCountryID = @NationalityCountryID,
	ImagePath = @ImagePath	WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@PersonID", PersonID);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            command.Parameters.AddWithValue("@FirstName", FirstName);

            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);

            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gendor", Gendor);

            command.Parameters.AddWithValue("@Address", Address);

            command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

#pragma warning disable CS0168 // Variable is declared but never used
            try { connection.Open(); rowsAffected = command.ExecuteNonQuery(); }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return (rowsAffected > 0);

        }
        public static bool DeletePeople(int PersonID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }


            return (rowsAffected > 0);

        }

        public static bool IsPeopleExist(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM People WHERE PersonID= @PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }


            return isFound;

        }

        public static bool IsPersonHasRealtionsInSystem(int ApplicantPersonID)
        {
            bool isFound = false;
            int PersonExists = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT CASE
                    WHEN EXISTS (SELECT 1 FROM Applications WHERE ApplicantPersonID = @ApplicantPersonID)
                    OR EXISTS (SELECT 1 FROM Drivers WHERE PersonID = @ApplicantPersonID)
                    THEN 1
                    ELSE 0
                    END AS PersonExists";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

#pragma warning disable CS0168 // Variable is declared but never used
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.Read())
                {

                    PersonExists = (int)reader["PersonExists"];

                    if (PersonExists == 1)
                        isFound = true;

                    else
                        isFound = false;

                    reader.Close();
                }
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }


            return isFound;

        }


        public static bool IsNationalNumberExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }


            return isFound;

        }


        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People";
            SqlCommand command = new SqlCommand(query, connection);

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

        public static int GetNumberOfPeople()
        {
            int NumberOfPeople = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select count (*) NumberOfPeople from People";
            SqlCommand command = new SqlCommand(query, connection);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    NumberOfPeople = (int)reader["NumberOfPeople"];
                }
                else
                {
                    return 0;
                }

                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return NumberOfPeople;


        }

        static string GetQueryFromFilter(string SerachingInfo, string Filter)
        {

            string query = "";
            switch (Filter)
            {

                case "Person ID":
                    {
                        query = @"   SELECT * FROM People WHERE PersonID LIKE @SerachingInfo";
                        return query;
                    }

                case "National No.":
                    {
                        query = @"   SELECT * FROM People WHERE NationalNo LIKE @SerachingInfo";
                        return query;
                    }

                case "First Name":
                    {
                        query = @"   SELECT * FROM People WHERE FirstName LIKE @SerachingInfo";
                        return query;
                    }

                case "Second Name":
                    {
                        query = @"SELECT * FROM People WHERE SecondName LIKE @SerachingInfo";
                        return query;
                    }

                case "Third Name":
                    {
                        query = @"SELECT * FROM People WHERE ThirdName LIKE @SerachingInfo";
                        return query;
                    }


                case "Last Name":
                    {
                        query = @"SELECT * FROM People WHERE LastName LIKE @SerachingInfo";
                        return query;
                    }


                case "Nationality":
                    {
                        query = @"SELECT * FROM People WHERE NationalityCountryID LIKE @SerachingInfo";
                        return query;
                    }

                case "Gender":
                    {
                        query = @"SELECT * FROM People WHERE Gendor LIKE @SerachingInfo";
                        return query;
                    }

                case "Phone":
                    {
                        query = @"SELECT * FROM People WHERE Phone LIKE @SerachingInfo";
                        return query;
                    }

                case "Email":
                    {
                        query = @"SELECT * FROM People WHERE Email LIKE @SerachingInfo";
                        return query;
                    }

            }
            return query;
        }

        public static DataTable GetPeopleByFilter(string SerachingInfo, string Filter)
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