using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public static class DataHandler
    {
        //static string serverURL = "KBS\\SQLEXPRESS";
        //static string database = "Technical_test";
        static readonly string connectionString = "Data Source=KBS\\SQLEXPRESS;Initial Catalog=Technical_test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public static void OpenConnection()
        {
            try
            {
                sqlConnection.Open();
                Console.WriteLine("Opened connection");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static string LoadData(string sql)
        {
            SqlDataReader sqlDataReader = null;
            SqlCommand districtsCommand = new SqlCommand(sql, sqlConnection);

            sqlDataReader = districtsCommand.ExecuteReader();

            string JSON = "";

            while (sqlDataReader.Read())
            {
                JSON = sqlDataReader[0].ToString();
            }

            sqlDataReader.Close();

            return JSON;
        }

        public static void SaveData(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

            sqlCommand.ExecuteNonQuery();
        }
    }
}
