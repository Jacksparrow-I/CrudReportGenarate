using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Customer_Invoice_Payment_Management.DataLogic.Concrete;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceServices _IInvoice;

        public InvoiceController(IInvoiceServices TblInvoice)
        {
            _IInvoice = TblInvoice;
        }

        [HttpGet("GetInvoices")]
        public List<Invoice> GetInvoices()
        {
            return _IInvoice.GetInvoices();
        }

        [HttpPost("AddInvoiceData")]
        public int AddInvoice([FromBody] TblInvoices InvoiceModel, string InvoiceNo)
        {
            return _IInvoice.AddInvoice(InvoiceModel, InvoiceNo);
        }

        [HttpPost("UpdateInvoice/{InvoiceNo}")]
        public int UpdateInvoice([FromBody] TblInvoices InvoiceModel, string InvoiceNo, string InvoiceName)
        {
            //**** move this below code to dependency injection ****
            return _IInvoice.UpdateInvoice(InvoiceModel, InvoiceNo, InvoiceName);
        }

        [HttpDelete("DeleteInvoice/{InvoiceNo}")]
        public int DeleteInvoice(string InvoiceNo)
        {
            return _IInvoice.DeleteInvoice(InvoiceNo);
        }

        [HttpGet("AutoIncrementInvoiceNo")]
        public List<Invoice> AutoIncrementInvoiceNo()
        {
            return _IInvoice.AutoIncrementInvoiceNo();
        }

        [HttpGet("GetInvoiceById/{InvoiceNo}")]
        public TblInvoices GetInvoiceById(string InvoiceNo)
        {
            return _IInvoice.GetInvoiceById(InvoiceNo);
        }
    }
}
