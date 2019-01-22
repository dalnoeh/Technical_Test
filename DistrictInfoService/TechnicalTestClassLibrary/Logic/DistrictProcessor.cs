using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestClassLibrary.DataAccess;
using TechnicalTestClassLibrary.Models;

namespace TechnicalTestClassLibrary.Logic
{
    public static class DistrictProcessor
    {
        public static void UpdateResponsibleSalesman(int districtID, int salesmanID)
        {
            string sql = $"UPDATE district_responsible_salesman SET responsible_salesman_ID = {salesmanID} WHERE district_ID = {districtID}";

            DataHandler.SaveData(sql);
        }

        public static void AddSecondarySalesman(int districID, int salesmanID)
        {
            string sql = $"INSERT INTO district_secondary_salesmen (district_ID, secondary_salesman_ID) VALUES ({districID}, {salesmanID})";

            DataHandler.SaveData(sql);
        }

        public static void RemoveSecondarySalesman(int districID, int salesmanID)
        {
            string sql = $"DELETE FROM district_secondary_salesmen WHERE district_ID = {districID} AND secondary_salesman_ID = {salesmanID}";

            DataHandler.SaveData(sql);
        }

        public static DistrictModel[] GetAllDistricts()
        {

            string sql = "select * from district for JSON AUTO, Include_Null_Values";

            string JSON = DataHandler.LoadData(sql);

            DistrictModel[] districts = districts = JsonConvert.DeserializeObject<DistrictModel[]>(JSON);

            return districts;
        }

        public static StoreModel[] GetStoresForDistrict(int district_id)
        {
            string sql = $"SELECT * FROM store WHERE store_ID IN (SELECT store_ID FROM district_store WHERE district_ID = {district_id}) " +
                $"FOR JSON AUTO, Include_Null_Values";

            string JSON = DataHandler.LoadData(sql);

            StoreModel[] stores = JsonConvert.DeserializeObject<StoreModel[]>(JSON);

            return stores;
        }

        public static SalesmanModel[] GetSecondarySalesmenForDistrict(int district_id)
        {
            string sql = $"SELECT * FROM salesman WHERE salesman_ID IN (SELECT secondary_salesman_ID FROM district_secondary_salesmen " +
                $"WHERE district_ID = {district_id}) FOR JSON AUTO, Include_Null_Values";

            string JSON = DataHandler.LoadData(sql);

            SalesmanModel[] salesmen = JsonConvert.DeserializeObject<SalesmanModel[]>(JSON);

            return salesmen;
        }

        public static SalesmanModel[] GetResponsibleSalesmenForDistrict(int district_id)
        {
            string sql = $"SELECT * FROM salesman WHERE salesman_ID IN (SELECT responsible_salesman_ID FROM district_responsible_salesman " +
                $"WHERE district_ID = {district_id}) FOR JSON AUTO, Include_Null_Values";

            string JSON = DataHandler.LoadData(sql);

            SalesmanModel[] salesmen = JsonConvert.DeserializeObject<SalesmanModel[]>(JSON);

            return salesmen;
        }



     }
}
