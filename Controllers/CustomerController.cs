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

namespace CrudReportGenerate.Controllers
{
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
            //**** move this below code to dependency injection ****
            return _ICustomer.UpdateCustomer(CustomerModel, CustomerNo, CustomerName);
        }

        [HttpDelete("DeleteCustomer/{CustomerNo}")]
        public int DeleteCustomer(string CustomerNo)
        {
            //**** move this below code to dependency injection ****
            return _ICustomer.DeleteCustomer(CustomerNo);
        }


    }
}
