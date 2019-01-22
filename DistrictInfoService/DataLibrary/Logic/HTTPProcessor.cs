using DataLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class HTTPProcessor
    {
        static HttpClient client = new HttpClient();
        static string URLPrefix = "https://localhost:44313/api/districts/";


        //public async static List<StoreModel> GetStoresForDistrict(int district_ID)
        //{
        //    string URL = $"{URLPrefix}GetStoresForDistrict/{district_ID}";

        //    string JSON = GetJSON(URL);

        //}

        public static async Task<string> GetJSON(string URL)
        {

            HttpResponseMessage data = await client.GetAsync(URL);

            string JSON = "";

            if (data.IsSuccessStatusCode)
            {
                JSON = await data.Content.ReadAsStringAsync();
            }

            return JSON;
        }
    }
}
