using System;
using System.Data;
using System.Data.SqlClient;

namespace CountriesDataAccessLayer
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString = "Server=TAREQ\\DB1;Database=DVLD;Integrated Security=true;";
    }

    public static class clsCountriesDataAccess
    {
        public static bool GetCountryInfoByID(int CountryID, ref string CountryName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    CountryID = (int)reader["CountryID"];
                    CountryName = (string)reader["CountryName"];

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

        public static string GetCountryNameByID(int CountryID)
        {
            string CountryName = "";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    CountryName = (string)reader["CountryName"];

                }
                else
                {
                    CountryName = "";
                }

                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return CountryName;

        }

        public static int GetCountryIDByName(string CountryName)
        {
            int CountryID = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT CountryID FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    CountryID = (int)reader["CountryID"];

                }
                else
                {
                    CountryID = -1;
                }

                reader.Close();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return CountryID;

        }

        public static int AddNewCountry(string CountryName)
        {

            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Countries VALUES (@CountryName)
        SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@CountryName", CountryName);


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
        public static bool UpdateCountry(int CountryID, string CountryName)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Countries
	SET	CountryName = @CountryName	WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@CountryID", CountryID);

            command.Parameters.AddWithValue("@CountryName", CountryName);


#pragma warning disable CS0168 // Variable is declared but never used
            try { connection.Open(); rowsAffected = command.ExecuteNonQuery(); }
            catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used
            finally { connection.Close(); }

            return (rowsAffected > 0);

        }
        public static bool DeleteCountry(int CountryID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

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

        public static bool IsCountryExist(int CountryID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Countries WHERE CountryID= @CountryID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

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

        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries";
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

        

    }

}