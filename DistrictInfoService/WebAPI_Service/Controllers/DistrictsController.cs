using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLibrary.Logic;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace WebAPI_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        // GET: api/Districts
        [HttpGet]
        public DistrictModel[] Get()
        {
            DataHandler.OpenConnection();
            return DistrictProcessor.GetAllDistricts();
        }

        //[Route("api/Districts/GetStoresForDistrict/{district_id:int}")]
        [HttpGet("GetStoresForDistrict/{district_ID}")]
        public StoreModel[] GetStoresForDistrict(int district_ID)
        {
            return DistrictProcessor.GetStoresForDistrict(district_ID);
        }

        //[Route("api/Districts/GetSecondarySalesmenForDistrict/{district_ID:int}")]
        [HttpGet("GetSecondarySalesmenForDistrict/{district_ID}")]
        public SalesmanModel[] GetSecondarySalesmenForDistrict(int district_ID)
        {
            return DistrictProcessor.GetSecondarySalesmenForDistrict(district_ID);
        }

        //[Route("api/Districts/GetResponsibleSalesmenForDistrict/{district_ID:int}")]
        [HttpGet("GetResponsibleSalesmenForDistrict/{district_ID}")]
        public SalesmanModel[] GetResponsibleSalesmenForDistrict(int district_ID)
        {
            return DistrictProcessor.GetResponsibleSalesmenForDistrict(district_ID);
        }

        //[Route("api/Districts/UpdateResponsibleSalesman/{district_ID:int}/{salesmanID:int}")]
        [HttpGet("UpdateResponsibleSalesman/{district_ID}/{salesman_ID}")]
        public void PostUpdateResponsibleSalesman(/*[FromBody]*/ int district_ID, int salesman_ID)
        {
            DistrictProcessor.UpdateResponsibleSalesman(district_ID, salesman_ID);
        }

        //[Route("api/Districts/AddSecondarySalesman/{district_ID:int}/{salesmanID:int}")]
        [HttpGet("AddSecondarySalesman/{district_ID}/{salesman_ID}")]
        public void AddSecondarySalesman(int district_ID, int salesman_ID)
        {
            DistrictProcessor.AddSecondarySalesman(district_ID, salesman_ID);
        }

        //[Route("api/Districts/RemoveSecondarySalesman/{district_ID:int}/{salesmanID:int}")]
        [HttpGet("RemoveSecondarySalesman/{district_ID}/{salesman_ID}")]
        public void DeleteSecondarySalesman(int district_ID, int salesman_ID)
        {
            DistrictProcessor.RemoveSecondarySalesman(district_ID, salesman_ID);
        }
    }
}
