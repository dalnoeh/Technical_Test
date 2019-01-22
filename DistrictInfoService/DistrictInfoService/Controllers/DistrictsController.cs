using DataLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DistrictInfoService.Controllers
{
    public static class DistrictsController
    {
        public static List<Store> GetStoresForDistrict(int id)
        {
            var storeData = DistrictProcessor.GetStoresForDistrict(id);

            List<Store> stores = new List<Store>();

            foreach (var store in storeData)
            {
                stores.Add(new Store
                {
                    store_ID = store.Store_ID,
                    name = store.Name
                });
            }

            return stores;
        }

        public static List<Salesman>[] GetSecondarySalesmenForDistrict(int id)
        {
            var secondarySalesmanData = DistrictProcessor.GetSecondarySalesmenForDistrict(id);

            List<Salesman> secondarySalesmen = new List<Salesman>();

            if (secondarySalesmanData != null)
            {

           

            foreach (var salesman in secondarySalesmanData)
            {
                
                    secondarySalesmen.Add(new Salesman
                    {
                        salesman_ID = salesman.Salesman_ID,
                        name = salesman.Name
                    });
            }
            }

            List<Salesman>[] salesmen = new List<Salesman>[2];

            salesmen[0] = secondarySalesmen;
            salesmen[1] = GetAvailableSalesmen(secondarySalesmen);

            return salesmen;
        }

        public static List<Salesman>[] GetResponsibleSalesmenForDistrict(int id)
        {
            var responsibleSalesmanData = DistrictProcessor.GetResponsibleSalesmenForDistrict(id);

            List<Salesman> responsibleSalesman = new List<Salesman>();

            foreach (var salesman in responsibleSalesmanData)
            {
                responsibleSalesman.Add(new Salesman
                {
                    salesman_ID = salesman.Salesman_ID,
                    name = salesman.Name
                });
            }

            List<Salesman>[] salesmen = new List<Salesman>[2];

            salesmen[0] = responsibleSalesman;
            salesmen[1] = GetNonResponsibleSalesmen(responsibleSalesman[0].salesman_ID);

            return salesmen;
        }

        public static void UpdateResponsibleSalesman(int districtID, int salesmanID)
        {
            DistrictProcessor.UpdateResponsibleSalesman(districtID, salesmanID);
        }

        public static void RemoveSecondarySalesman(int districID, int salesmanID)
        {
            DistrictProcessor.RemoveSecondarySalesman(districID, salesmanID);
        }

        public static void AddSecondarySalesman(int districID, int salesmanID)
        {
            DistrictProcessor.AddSecondarySalesman(districID, salesmanID);
        }

        private static List<Salesman> GetAvailableSalesmen(List<Salesman> secondarySalesmen)
        {
            var allSalesmenarray = SalesmenProcessor.GetAllSalesmen();

            List<Salesman> allSalesmen = new List<Salesman>();

            foreach (var salesmen in allSalesmenarray)
            {
                allSalesmen.Add(new Salesman
                {
                    salesman_ID = salesmen.Salesman_ID,
                    name = salesmen.Name,
                });
            }

            List<Salesman> availableSalesmen = new List<Salesman>();

            for (int i = 0; i < allSalesmen.Count; i++)
            {
                bool foundSalesman = false;
                for (int j = 0; j < secondarySalesmen.Count; j++)
                {
                    if (secondarySalesmen[j].salesman_ID == allSalesmen[i].salesman_ID)
                    {
                        foundSalesman = true;
                    }
                }

                if (foundSalesman == false)
                {
                    availableSalesmen.Add(allSalesmen[i]);

                }
                
            }

            return availableSalesmen;
        }

        private static List<Salesman> GetNonResponsibleSalesmen(int responsibleSalesman_id)
        {
            var allSalesmenarray = SalesmenProcessor.GetAllSalesmen();

            List<Salesman> allNonResponsibleSalesmen = new List<Salesman>();

            foreach (var salesmen in allSalesmenarray)
            {
                if (salesmen.Salesman_ID != responsibleSalesman_id)
                {
                    allNonResponsibleSalesmen.Add(new Salesman
                    {
                        salesman_ID = salesmen.Salesman_ID,
                        name = salesmen.Name,
                    });
                }
            }

            return allNonResponsibleSalesmen;
        }
    }
    
}
