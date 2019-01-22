using DataLibrary.DataAccess;
using DataLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class SalesmenProcessor
    {
        public static SalesmanModel[] GetAllSalesmen()
        {

            string sql = "select * from salesman for JSON AUTO, Include_Null_Values";

            string JSON = DataHandler.LoadData(sql);

            SalesmanModel[] salesmen = JsonConvert.DeserializeObject<SalesmanModel[]>(JSON);

            return salesmen;
        }
    }
}
