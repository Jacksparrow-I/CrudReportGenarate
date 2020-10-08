using System;
using System.Collections.Generic;

namespace CrudReportGenerate.Model.Entity
{
    public partial class TblInvoices
    {
        public string InvoiceNo { get; set; }
        public string CustomerNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceAmount { get; set; }
        public DateTime PaymentDueDate { get; set; }
    }
}
