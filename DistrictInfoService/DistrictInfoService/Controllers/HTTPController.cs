using DataLibrary.Logic;
using DataLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DistrictInfoService.Controllers
{
    public static class HTTPController
    {

        static HttpClient client = new HttpClient();

        static string URLPrefix = "https://localhost:44313/api/districts/";
        //public static async List<Store> GetStoresForDistrict(int district_ID)
        //{
        //    var storeModels =  HTTPProcessor.GetStoresForDistrict(district_ID);

        //    List<Store> stores = new List<Store>();

        //    foreach (var store in storeData)
        //    {
        //        stores.Add(new Store
        //        {
        //            store_ID = store.Store_ID,
        //            name = store.Name
        //        });
        //    }

        //    return stores;
        //}

        static async Task<StoreModel[]> GetStoresForDistrict(HttpResponseMessage data)
        {

            StoreModel[] stores = null;

            if (data.IsSuccessStatusCode)
            {
                string JSON = await data.Content.ReadAsStringAsync();
                stores = JsonConvert.DeserializeObject<StoreModel[]>(JSON);
            }

            return stores;
        }

        

    }
}
