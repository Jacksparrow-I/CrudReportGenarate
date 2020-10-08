using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CrudReportGenerate.Model.Common;
using CrudReportGenerate.Repository;
using CrudReportGenerate.Interface;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace CrudReportGenerate.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _ICustomer;

        public CustomerController(ICustomer TblCustomer)
        {
            _ICustomer = TblCustomer;
        }

        [HttpGet("GetCustomer")]
        public List<Model.Common.Customer> GetCustomer()
        {
            return _ICustomer.GetCustomer();
        }

        [HttpPost("AddCustomerData")]
        public int AddCustomerData([FromBody] Customer CustomerModel, string CustomerNo)
        {
            return _ICustomer.AddCustomerData(CustomerModel, CustomerNo);
        }

        [HttpPost("UpdateCustomer/{CustomerNo}")]
        public int UpdateCustomer([FromBody] Customer CustomerModel, string CustomerNo, string CustomerName)
        {
            return _ICustomer.UpdateCustomer(CustomerModel, CustomerNo, CustomerName);
        }

        [HttpDelete("DeleteCustomer/{CustomerNo}")]
        public int DeleteCustomer(string CustomerNo)
        {
            return _ICustomer.DeleteCustomer(CustomerNo);
        }

        [HttpGet("CustomerById/{CustomerNo}")]
        public Customer CustomerById(string CustomerNo)
        {
            return _ICustomer.CustomerById(CustomerNo);
        }


    }
}
