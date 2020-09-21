using System;
using System.Collections.Generic;

namespace CrudReportGenerate.Model.Common
{
    public class Payment
    {
        public string PaymentNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmount { get; set; }
    }
}
