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

namespace CrudReportGenerate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
    }
}
