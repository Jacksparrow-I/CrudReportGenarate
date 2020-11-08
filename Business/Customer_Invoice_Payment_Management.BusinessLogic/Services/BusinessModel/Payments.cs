using System;
using System.Collections.Generic;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel
{
    public partial class Payments
    {
        public string PaymentNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
