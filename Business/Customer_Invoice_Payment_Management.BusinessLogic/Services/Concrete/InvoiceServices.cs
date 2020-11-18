using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IInvoice _Invoice;
        public InvoiceServices( IInvoice Invoice)
        {
            _Invoice = Invoice;

        }
        public int AddInvoice(TblInvoices InvoiceModel, string InvoiceNo)
        {
            return _Invoice.AddInvoice(InvoiceModel, InvoiceNo);
        }

        public List<Invoice> AutoIncrementInvoiceNo()
        {
            return _Invoice.AutoIncrementInvoiceNo();
        }

        public int DeleteInvoice(string InvoiceNo)
        {
            return _Invoice.DeleteInvoice(InvoiceNo);
        }

        public List<Invoice> GetInvoices()
        {
            return _Invoice.GetInvoices();
        }

        public TblInvoices GetInvoiceById(string InvoiceNo)
        {
            return _Invoice.GetInvoiceById(InvoiceNo);
        }

        public int UpdateInvoice(TblInvoices InvoiceModel, string InvoiceNo, string InvoiceName)
        {
            return _Invoice.UpdateInvoice(InvoiceModel, InvoiceNo, InvoiceName);
        }
    }
}
