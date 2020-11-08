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
    public class PaymentServices : IPaymentServices
    {
        private readonly IMapper _imapper;
        private readonly IPayment _Payment;
        public PaymentServices(IMapper imapper, IPayment Payment)
        {
            _imapper = imapper;
            _Payment = Payment;

        }

        public int AddPaymentData(Payments PaymentModel, string PaymentNo)
        {
            return _Payment.AddPaymentData(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.TblPayment>(PaymentModel), PaymentNo);
        }

        public List<Payment> AutoIncrementPaymentNo()
        {
            return _imapper.Map<List<Payment>>(_Payment.AutoIncrementPaymentNo());
        }

        public int DeletePayment(string PaymentNo)
        {
            return _Payment.DeletePayment(PaymentNo);
        }

        public List<Invoice> GetInvoiceDetails(string Number)
        {
            return _imapper.Map<List<Invoice>>(_Payment.GetInvoiceDetails(Number));
        }

        public List<Payment> GetPayment()
        {
            return _imapper.Map<List<Payment>>(_Payment.GetPayment());
        }

        public Payments PaymentById(string PaymentNo)
        {
            return _imapper.Map<Payments>(_Payment.PaymentById(PaymentNo));
        }

        public int UpdatePayment(Payments PaymentModel, string PaymentNo, string PaymentName)
        {
            return _Payment.UpdatePayment(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.TblPayment>(PaymentModel), PaymentNo, PaymentName);
        }
    }
}
