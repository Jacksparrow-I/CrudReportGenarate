using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface IPaymentServices
    {
        public List<Payment> GetPayment();
        public int AddPaymentData(Payments PaymentModel, string PaymentNo);
        public int UpdatePayment(Payments PaymentModel, string PaymentNo, string PaymentName);
        public int DeletePayment(string PaymentNo);
        public Payments PaymentById(string PaymentNo);
        public List<Invoice> GetInvoiceDetails(string Number);
        public List<Payment> AutoIncrementPaymentNo();
    }
}
