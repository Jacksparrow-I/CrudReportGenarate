
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class DashbordServices : IDashboardServices
    {
        private readonly IDashboard _Dashboard;
        public DashbordServices(IDashboard Dashboard)
        {
            _Dashboard = Dashboard;
        }

        public List<Chart> DisplayChart()
        {
            return _Dashboard.DisplayChart();
        }

        public int Editprofile(User UserModel, string UserName, int UserId)
        {
            return _Dashboard.Editprofile(UserModel, UserName, UserId);
        }

        public List<Dashboard> GetDashboardDetails()
        {
            return _Dashboard.GetDashboardDetails();
        }

        public User GetEditprofileById(int UserId)
        {
            return _Dashboard.GetEditprofileById(UserId);
        }
    }
}
