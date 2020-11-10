using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface IPaymentServices
    {
        public List<Payment> GetPayment();
        public int AddPayment(TblPayment PaymentModel, string PaymentNo);
        public int UpdatePayment(TblPayment PaymentModel, string PaymentNo, string PaymentName);
        public int DeletePayment(string PaymentNo);
        public TblPayment PaymentById(string PaymentNo);
        public List<Invoice> GetInvoiceDetails(string Number);
        public List<Payment> AutoIncrementPaymentNo();
    }
}
