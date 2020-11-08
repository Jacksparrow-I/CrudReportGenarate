using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface IInvoiceServices
    {
        public List<Invoice> GetInvoice();
        public int AddInvoiceData(Invoices InvoiceModel, string InvoiceNo);
        public int UpdateInvoice(Invoices InvoiceModel, string InvoiceNo, string InvoiceName);
        public int DeleteInvoice(string InvoiceNo);
        public Invoices InvoiceById(string InvoiceNo);
        public List<Invoice> AutoIncrementInvoiceNo();
    }
}
