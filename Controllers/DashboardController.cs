using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudReportGenerate.Interface;
using CrudReportGenerate.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudReportGenerate.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IDashboard _IDashboard;
        public DashboardController(IDashboard Dashboard)
        {
            _IDashboard = Dashboard;
        }

        [HttpGet("GetDashboardDetails")]
        public List<Dashboard> GetDashboardDetails()
        {
            return _IDashboard.GetDashboardDetails();
        }
    }
}
