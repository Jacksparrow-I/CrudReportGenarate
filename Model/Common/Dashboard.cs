using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Model.Common
{
    public class Dashboard
    {
        public int TotalCustomer { get; set; }
        public int TotalInvoice { get; set; }
        public int TotalSales{ get; set; }
        public int TotalPayCollection { get; set; }

        //[DisplayFormat(DataFormatString = "{​​​​0:MM/yyyy}​​​​", ApplyFormatInEditMode = true)]
        public DateTime MonthAndYearDate { get; set; }
        //public DateTime ChartPaymentDate { get; set; }
        public int ChartPayment { get; set; }
        //public DateTime ChartSalesDate { get; set; }
        public int ChartSales { get; set; }
        //public int ChartMonthly { get; set; }
        //public int ChartYearly { get; set; }

    }
}
