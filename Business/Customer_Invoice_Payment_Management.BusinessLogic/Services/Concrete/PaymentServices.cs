using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPayment _Payment;
        public PaymentServices(IPayment Payment)
        {
            _Payment = Payment;

        }

        public int AddPayment(TblPayment PaymentModel, string PaymentNo)
        {
            return _Payment.AddPayment(PaymentModel, PaymentNo);
        }

        public List<Payment> AutoIncrementPaymentNo()
        {
            return _Payment.AutoIncrementPaymentNo();
        }

        public int DeletePayment(string PaymentNo)
        {
            return _Payment.DeletePayment(PaymentNo);
        }

        public List<Invoice> GetInvoiceDetails(string Number)
        {
            return _Payment.GetInvoiceDetails(Number);
        }

        public List<Payment> GetPayment()
        {
            return _Payment.GetPayment();
        }

        public TblPayment PaymentById(string PaymentNo)
        {
            return _Payment.PaymentById(PaymentNo);
        }

        public int UpdatePayment(TblPayment PaymentModel, string PaymentNo, string PaymentName)
        {
            return _Payment.UpdatePayment(PaymentModel, PaymentNo, PaymentName);
        }
    }
}
