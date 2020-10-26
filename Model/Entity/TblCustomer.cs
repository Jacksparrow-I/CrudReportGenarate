using System;
using System.Collections.Generic;

namespace CrudReportGenerate.Model.Entity
{
    public partial class TblCustomer
    {
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
    }
}
