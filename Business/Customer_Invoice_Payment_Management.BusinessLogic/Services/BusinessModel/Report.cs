using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel
{
    public class Report
    {
        public int Num { get; set; }
        public DateTime DateOfMonthInvoice { get; set; }
        public DateTime DateOfMonthPay { get; set; }
        public DateTime DateOfMonth { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public Decimal NoofInvoice { get; set; }
        public Decimal Sales { get; set; }
        public Decimal PayCollection { get; set; }
    }
}
