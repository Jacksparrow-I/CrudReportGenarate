using AutoMapper;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class ReportServices : IReportServices
    {
        private readonly IMapper _imapper;
        private readonly IReport _Report;
        public ReportServices(IMapper imapper, IReport Report)
        {
            _imapper = imapper;
            _Report = Report;

        }
        public List<Report> GetReports()
        {
            return _imapper.Map<List<Report>>(_Report.GetReports());
        }
    }
}
