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
        public List<Dashboard> DisplayChart();
        public int Editprofile(Userdata UserModel, string UserName, int UserId);
        public Userdata GetEditprofileById(int UserId);
    }
}
