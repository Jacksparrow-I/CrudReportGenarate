using CrudReportGenerate.Model.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Interface
{
    public interface IInvoice
    {
        public List<Invoice> GetInvoice();
        public int AddInvoiceData(Invoice InvoiceModel, string InvoiceNo);
        public int UpdateInvoice(Invoice InvoiceModel, string InvoiceNo, string InvoiceName);
        public int DeleteInvoice(string InvoiceNo);
    }
}
