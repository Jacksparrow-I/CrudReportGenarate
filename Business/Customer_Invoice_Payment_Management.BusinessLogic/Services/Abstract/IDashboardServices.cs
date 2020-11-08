using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface IDashboardServices
    {
        public List<Dashboards> GetDashboardDetails();
        public List<Charts> DisplayChart();
        public int Editprofile(user UserModel, string UserName, int UserId);
        public user GetEditprofileById(int UserId);
    }
}
