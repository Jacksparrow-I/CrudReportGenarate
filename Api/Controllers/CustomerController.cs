using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Customer_Invoice_Payment_Management.DataLogic.Concrete;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.Model.Common;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;

namespace CrudReportGenerate.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _CustomerServices;

        public CustomerController(ICustomerServices CustomerServices)
        {
            _CustomerServices = CustomerServices;
        }

        [HttpGet("GetCustomers")]
        public List<Customer> GetCustomers()
        {
            return _CustomerServices.GetCustomers();
        }

        [HttpPost("AddCustomer")]
        public int AddCustomer([FromBody] TblCustomer CustomerModel, string CustomerNo)
        {
            return _CustomerServices.AddCustomer(CustomerModel, CustomerNo);
        }

        [HttpPost("UpdateCustomer/{CustomerNo}")]
        public int UpdateCustomer([FromBody] TblCustomer CustomerModel, string CustomerNo, string CustomerName)
        {
            return _CustomerServices.UpdateCustomer(CustomerModel, CustomerNo, CustomerName);
        }

        [HttpDelete("DeleteCustomer/{CustomerNo}")]
        public int DeleteCustomer(string CustomerNo)
        {
            return _CustomerServices.DeleteCustomer(CustomerNo);
        }

        [HttpGet("AutoIncrementCustomerNo")]
        public List<Customer> AutoIncrementCustomerNo()
        {
            return _CustomerServices.AutoIncrementCustomerNo();
        }

        [HttpGet("GetCustomerById/{CustomerNo}")]
        public TblCustomer GetCustomerById(string CustomerNo)
        {
            return _CustomerServices.GetCustomerById(CustomerNo);
        }


    }
}
