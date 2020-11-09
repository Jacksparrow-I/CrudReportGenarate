using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class ReportServices : IReportServices
    {
        private readonly IReport _Report;
        public ReportServices(IReport Report)
        {
            _Report = Report;

        }
        public List<Reports> GetReports()
        {
            return _Report.GetReports();
        }
    }
}
