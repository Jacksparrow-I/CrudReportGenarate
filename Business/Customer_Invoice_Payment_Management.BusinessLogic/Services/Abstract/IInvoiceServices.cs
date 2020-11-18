using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface IInvoiceServices
    {
        public List<Invoice> GetInvoices();
        public int AddInvoice(TblInvoices InvoiceModel, string InvoiceNo);
        public int UpdateInvoice(TblInvoices InvoiceModel, string InvoiceNo, string InvoiceName);
        public int DeleteInvoice(string InvoiceNo);
        public TblInvoices GetInvoiceById(string InvoiceNo);
        public List<Invoice> AutoIncrementInvoiceNo();
    }
}
