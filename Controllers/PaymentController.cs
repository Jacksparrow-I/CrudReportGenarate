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
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _IPayment;

        public PaymentController(IPayment TblPayment)
        {
            _IPayment = TblPayment;
        }

        [HttpGet("GetPayment")]
        public List<Model.Common.Payment> GetPayment()
        {
            return _IPayment.GetPayment();
        }

        [HttpPost("AddPaymentData")]
        public int AddPaymentData([FromBody] Payment PaymentModel, string PaymentNo)
        {
            return _IPayment.AddPaymentData(PaymentModel, PaymentNo);
        }

        [HttpPost("UpdatePayment/{InvoiceNo}")]
        public int UpdatePayment([FromBody] Payment PaymentModel, string PaymentNo, string PaymentName)
        {
            //**** move this below code to dependency injection ****
            return _IPayment.UpdatePayment(PaymentModel, PaymentNo, PaymentName);
        }

        [HttpDelete("DeletePayment/{PaymentNo}")]
        public int DeletePayment(string PaymentNo)
        {
            //**** move this below code to dependency injection ****
            return _IPayment.DeletePayment(PaymentNo);
        }

        [HttpGet("PaymentById/{PaymentNo}")]
        public Payment PaymentById(string PaymentNo)
        {
            return _IPayment.PaymentById(PaymentNo);
        }
    }
}
