using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TechnicalTestClassLibrary.DataAccess
{
     public static class DataHandler
    {
        //static string serverURL = "KBS\\SQLEXPRESS";
        //static string database = "Technical_test";
        static string connectionString = "Data Source=KBS\\SQLEXPRESS;Initial Catalog=Technical_test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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

        //public static DistrictModel[] GetDistricts()
        //{
        //    string data;


        //    SqlDataReader sqlDataReader = null;
        //    SqlCommand districtsCommand = new SqlCommand("select * from district for JSON AUTO, " +
        //        "Include_Null_Values", sqlConnection);

        //    sqlDataReader = districtsCommand.ExecuteReader();


        //    DistrictModel[] districts = new DistrictModel[0];

        //    while (sqlDataReader.Read())
        //    {
        //        data = sqlDataReader[0].ToString();
        //        //Console.WriteLine(sqlDataReader[0].ToString());

        //        districts = JsonConvert.DeserializeObject<DistrictModel[]>(data);


        //    }

        //    sqlDataReader.Close();

        //    foreach (DistrictModel d in districts)
        //    {
        //        Console.WriteLine(d.district_ID + " " + d.name);
        //    }

        //    return districts;

        //}

        //public static StoreModel[] GetStoresForDistrict(int district_id)
        //{
        //    string data;


        //    SqlDataReader sqlDataReader = null;

        //    string commandStr = $"SELECT * FROM store WHERE store_ID IN (SELECT store_ID FROM district_store " +
        //        $"WHERE district_ID = {district_id}) " +
        //        $"for JSON AUTO, Include_Null_Values";

        //    SqlCommand storeCommand = new SqlCommand(commandStr, sqlConnection);

        //    sqlDataReader = storeCommand.ExecuteReader();


        //    StoreModel[] stores = new StoreModel[0];

        //    while (sqlDataReader.Read())
        //    {
        //        data = sqlDataReader[0].ToString();
        //        //Console.WriteLine(sqlDataReader[0].ToString());

        //        stores = JsonConvert.DeserializeObject<StoreModel[]>(data);


        //    }

        //    sqlDataReader.Close();

        //    foreach (StoreModel s in stores)
        //    {
        //        Console.WriteLine(s.store_ID + " " + s.name);
        //    }

        //    return stores;

        //}

        //public static SalesmanModel[] GetSecondarySalesmenForDistrict(int district_id)
        //{
        //    string data;


        //    SqlDataReader sqlDataReader = null;

        //    string commandStr = $"SELECT * FROM salesman WHERE salesman_ID IN (SELECT secondary_salesman_ID FROM district_secondary_salesmen " +
        //        $"WHERE district_ID = {district_id}) " +
        //        $"for JSON AUTO, Include_Null_Values";

        //    SqlCommand salesmenCommand = new SqlCommand(commandStr, sqlConnection);

        //    sqlDataReader = salesmenCommand.ExecuteReader();


        //    SalesmanModel[] salesmen = new SalesmanModel[0];

        //    while (sqlDataReader.Read())
        //    {
        //        data = sqlDataReader[0].ToString();
        //        //Console.WriteLine(sqlDataReader[0].ToString());

        //        salesmen = JsonConvert.DeserializeObject<SalesmanModel[]>(data);


        //    }

        //    sqlDataReader.Close();

        //    foreach (SalesmanModel s in salesmen)
        //    {
        //        Console.WriteLine(s.salesman_ID + " " + s.name);
        //    }

        //    return salesmen;

        //}

        //public static SalesmanModel[] GetResponsibleSalesmenForDistrict(int district_id)
        //{
        //    string data;


        //    SqlDataReader sqlDataReader = null;

        //    string commandStr = $"SELECT * FROM salesman WHERE salesman_ID IN (SELECT responsible_salesman_ID FROM district_responsible_salesman " +
        //        $"WHERE district_ID = {district_id}) " +
        //        $"for JSON AUTO, Include_Null_Values";

        //    SqlCommand salesmanCommand = new SqlCommand(commandStr, sqlConnection);

        //    sqlDataReader = salesmanCommand.ExecuteReader();


        //    SalesmanModel[] salesman = new SalesmanModel[0];

        //    while (sqlDataReader.Read())
        //    {
        //        data = sqlDataReader[0].ToString();
        //        //Console.WriteLine(sqlDataReader[0].ToString());

        //        salesman = JsonConvert.DeserializeObject<SalesmanModel[]>(data);
        //    }

        //    sqlDataReader.Close();

            
            
        //        Console.WriteLine(salesman[0].salesman_ID + " " + salesman[0].name);
            

        //    return salesman;

        //}

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
