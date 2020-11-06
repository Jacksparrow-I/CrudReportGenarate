using System;
using System.Collections.Generic;

namespace Customer_Invoice_Payment_Management.Model.Common
{
    public class Invoice
    {
        public string InvoiceNo { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceAmount { get; set; }
        public DateTime PaymentDueDate { get; set; }

        //Payment Repositary
        public int PaymentAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
