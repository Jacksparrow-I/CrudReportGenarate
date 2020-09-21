using System;
using System.Collections.Generic;

namespace CrudReportGenerate.Models.Entity
{
    public partial class TblPayment
    {
        public string PaymentNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentAmount { get; set; }
    }
}
