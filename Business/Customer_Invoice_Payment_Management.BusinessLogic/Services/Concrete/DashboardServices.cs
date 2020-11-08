using AutoMapper;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class DashbordServices : IDashboardServices
    {
        private readonly IMapper _imapper;
        private readonly IDashboard _Dashboard;
        public DashbordServices(IMapper imapper, IDashboard Dashboard)
        {
            _imapper = imapper;
            _Dashboard = Dashboard;
        }

        public List<Charts> DisplayChart()
        {
            return _imapper.Map<List<Charts>>(_Dashboard.DisplayChart());
        }

        public int Editprofile(user UserModel, string UserName, int UserId)
        {
            return _Dashboard.Editprofile(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.User>(UserModel), UserName, UserId);
        }

        public List<Dashboards> GetDashboardDetails()
        {
            return _imapper.Map<List<Dashboards>>(_Dashboard.GetDashboardDetails());
        }

        public user GetEditprofileById(int UserId)
        {
            return _imapper.Map<user>(_Dashboard.GetEditprofileById(UserId));
        }
    }
}
