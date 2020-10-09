using CrudReportGenerate.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Interface
{
    public interface IDashboard
    {
        public List<Dashboard> GetDashboardDetails();
    }
}
