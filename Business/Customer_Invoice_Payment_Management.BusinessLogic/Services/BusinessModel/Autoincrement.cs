using System;
using System.Collections.Generic;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel
{
    public partial class Autoincrement
    {
        public int AutoId { get; set; }
        public int AutoCustomerNo { get; set; }
        public int AutoInvoiceNo { get; set; }
        public int AutoPaymentNo { get; set; }
    }
}
