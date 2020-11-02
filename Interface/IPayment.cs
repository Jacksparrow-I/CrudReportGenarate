using CrudReportGenerate.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Interface
{
    public interface IPayment
    {
        public List<Model.Common.Payment> GetPayment();
        public int AddPaymentData(Payment PaymentModel, string PaymentNo);
        public int UpdatePayment(Payment PaymentModel, string PaymentNo, string PaymentName);
        public int DeletePayment(string PaymentNo);
        public Payment PaymentById(string PaymentNo);
        public List<Model.Common.Invoice> GetInvoiceDetails(string Number);
        public List<Payment> AutoIncrementPaymentNo();

    }
}
