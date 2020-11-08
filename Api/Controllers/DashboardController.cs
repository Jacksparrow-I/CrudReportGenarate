using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;

namespace CrudReportGenerate.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IDashboardServices _IDashboard;
        public DashboardController(IDashboardServices Dashboard)
        {
            _IDashboard = Dashboard;
        }

        [HttpGet("GetDashboardDetails")]
        public List<Dashboards> GetDashboardDetails()
        {
            return _IDashboard.GetDashboardDetails();
        }


        [HttpGet("DisplayChart")]
        public List<Charts> DisplayChart()
        {
            return _IDashboard.DisplayChart();
        }

        [HttpPost("Editprofile/{UserID}")]
        public int Editprofile([FromBody] user UserModel, string UserName, int UserId)
        {
            return _IDashboard.Editprofile(UserModel, UserName, UserId);
        }

        [HttpGet("GetEditprofileById/{UserId}")]
        public user GetEditprofileById(int UserId)
        {
            return _IDashboard.GetEditprofileById(UserId);
        }
    }
}
