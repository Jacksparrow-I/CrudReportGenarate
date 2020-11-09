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
        public int AddInvoiceData(TblInvoices InvoiceModel, string InvoiceNo)
        {
            return _Invoice.AddInvoiceData(InvoiceModel, InvoiceNo);
        }

        public List<Invoice> AutoIncrementInvoiceNo()
        {
            return _Invoice.AutoIncrementInvoiceNo();
        }

        public int DeleteInvoice(string InvoiceNo)
        {
            return _Invoice.DeleteInvoice(InvoiceNo);
        }

        public List<Invoice> GetInvoice()
        {
            return _Invoice.GetInvoice();
        }

        public TblInvoices InvoiceById(string InvoiceNo)
        {
            return _Invoice.InvoiceById(InvoiceNo);
        }

        public int UpdateInvoice(TblInvoices InvoiceModel, string InvoiceNo, string InvoiceName)
        {
            return _Invoice.UpdateInvoice(InvoiceModel, InvoiceNo, InvoiceName);
        }
    }
}
