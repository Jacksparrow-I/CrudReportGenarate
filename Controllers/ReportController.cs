using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CrudReportGenerate.Model.Common;
using CrudReportGenerate.Repository;
using CrudReportGenerate.Interface;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace CrudReportGenerate.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReport _IReport;

        public ReportController(IReport Report)
        {
            _IReport = Report;
        }

        [HttpGet("GetReports")]
        public List<Model.Common.Reports> GetReports()
        {
            return _IReport.GetReports();
        }
    }
}
