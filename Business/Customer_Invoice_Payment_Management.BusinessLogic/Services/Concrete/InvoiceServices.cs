
using AutoMapper;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IMapper _imapper;
        private readonly IInvoice _Invoice;
        public InvoiceServices(IMapper imapper, IInvoice Invoice)
        {
            _imapper = imapper;
            _Invoice = Invoice;

        }
        public int AddInvoiceData(Invoices InvoiceModel, string InvoiceNo)
        {
            return _Invoice.AddInvoiceData(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.TblInvoices>(InvoiceModel), InvoiceNo);
        }

        public List<Invoice> AutoIncrementInvoiceNo()
        {
            return _imapper.Map<List<Invoice>>(_Invoice.AutoIncrementInvoiceNo());
        }

        public int DeleteInvoice(string InvoiceNo)
        {
            return _Invoice.DeleteInvoice(InvoiceNo);
        }

        public List<Invoice> GetInvoice()
        {
            return _imapper.Map<List<Invoice>>(_Invoice.GetInvoice());
        }

        public Invoices InvoiceById(string InvoiceNo)
        {
            return _imapper.Map<Invoices>(_Invoice.InvoiceById(InvoiceNo));
        }

        public int UpdateInvoice(Invoices InvoiceModel, string InvoiceNo, string InvoiceName)
        {
            return _Invoice.UpdateInvoice(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.TblInvoices>(InvoiceModel), InvoiceNo, InvoiceName);
        }
    }
}
