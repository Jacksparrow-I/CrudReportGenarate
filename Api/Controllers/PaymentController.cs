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
using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.Model.Common;

namespace CrudReportGenerate.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _IPayment;

        public PaymentController(IPaymentServices TblPayment)
        {
            _IPayment = TblPayment;
        }

        [HttpGet("GetPayment")]
        public List<Payment> GetPayment()
        {
            return _IPayment.GetPayment();
        }

        [HttpPost("AddPaymentData")]
        public int AddPaymentData([FromBody] Payments PaymentModel, string PaymentNo)
        {
            return _IPayment.AddPaymentData(PaymentModel, PaymentNo);
        }

        [HttpPost("UpdatePayment/{InvoiceNo}")]
        public int UpdatePayment([FromBody] Payments PaymentModel, string PaymentNo, string PaymentName)
        {
            //**** move this below code to dependency injection ****
            return _IPayment.UpdatePayment(PaymentModel, PaymentNo, PaymentName);
        }

        [HttpDelete("DeletePayment/{PaymentNo}")]
        public int DeletePayment(string PaymentNo)
        {
            return _IPayment.DeletePayment(PaymentNo);
        }

        [HttpGet("AutoIncrementPaymentNo")]
        public List<Payment> AutoIncrementPaymentNo()
        {
            return _IPayment.AutoIncrementPaymentNo();
        }

        [HttpGet("PaymentById/{PaymentNo}")]
        public Payments PaymentById(string PaymentNo)
        {
            return _IPayment.PaymentById(PaymentNo);
        }

        [HttpGet("GetInvoiceDetails/{Number}")]
        public List<Invoice> GetInvoiceDetails(string Number)
        {
            return _IPayment.GetInvoiceDetails(Number);
        }

    }
}
