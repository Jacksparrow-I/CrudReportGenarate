using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Model.Common
{
    public class Chart
    {

        //[DisplayFormat(DataFormatString = "{​​​​0:MM/yyyy}​​​​", ApplyFormatInEditMode = true)]
        public DateTime MonthAndYearDate { get; set; }
        //public int ChartPayment { get; set; }
        public int ChartSales { get; set; }

    }
}
