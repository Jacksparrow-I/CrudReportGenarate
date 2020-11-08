using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Customer_Invoice_Payment_Management.DataLogic.Concrete;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;

namespace CrudReportGenerate.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportServices _IReport;

        public ReportController(IReportServices Report)
        {
            _IReport = Report;
        }

        [HttpGet("GetReports")]
        public List<Report> GetReports()
        {
            return _IReport.GetReports();
        }
    }
}
