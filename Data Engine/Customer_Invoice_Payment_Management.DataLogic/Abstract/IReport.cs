using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Invoice_Payment_Management.DataLogic.Abstract
{
    public interface IReport
    {
        public List<Reports> GetReports();
    }
}
