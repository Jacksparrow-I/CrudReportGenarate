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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice _IInvoice;

        public InvoiceController(IInvoice TblInvoice)
        {
            _IInvoice = TblInvoice;
        }

        [HttpGet("GetInvoice")]
        public List<Model.Common.Invoice> GetInvoice()
        {
            return _IInvoice.GetInvoice();
        }

        [HttpPost("AddInvoiceData")]
        public int AddInvoiceData([FromBody] Invoice InvoiceModel, string InvoiceNo)
        {
            return _IInvoice.AddInvoiceData(InvoiceModel, InvoiceNo);
        }

        [HttpPost("UpdateInvoice/{InvoiceNo}")]
        public int UpdateInvoice([FromBody] Invoice InvoiceModel, string InvoiceNo, string InvoiceName)
        {
            //**** move this below code to dependency injection ****
            return _IInvoice.UpdateInvoice(InvoiceModel, InvoiceNo, InvoiceName);
        }

        [HttpDelete("DeleteInvoice/{InvoiceNo}")]
        public int DeleteInvoice(string InvoiceNo)
        {
            //**** move this below code to dependency injection ****
            return _IInvoice.DeleteInvoice(InvoiceNo);
        }
    }
}
