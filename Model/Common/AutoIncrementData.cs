using System;
using System.Collections.Generic;

namespace CrudReportGenerate.Model.Common
{
    public partial class AutoIncrementData
    {
        public int AutoId { get; set; }
        public int AutoCustomerNo { get; set; }
        public int AutoInvoiceNo { get; set; }
        public int AutoPaymentNo { get; set; }
    }
}
