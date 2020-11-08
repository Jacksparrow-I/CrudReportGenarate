using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface IReportServices
    {
        public List<Report> GetReports();
    }
}
