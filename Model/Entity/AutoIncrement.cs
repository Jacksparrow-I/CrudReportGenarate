using System;
using System.Collections.Generic;

namespace CrudReportGenerate.Model.Entity
{
    public partial class AutoIncrement
    {
        public int AutoId { get; set; }
        public int AutoCustomerNo { get; set; }
        public int AutoInvoiceNo { get; set; }
        public int AutoPaymentNo { get; set; }
    }
}
