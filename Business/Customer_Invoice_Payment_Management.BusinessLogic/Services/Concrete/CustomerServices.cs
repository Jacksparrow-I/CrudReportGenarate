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
    public class CustomerServices : ICustomerServices
    {
        private readonly IMapper _imapper;
        private readonly ICustomer _Customer;
        public CustomerServices(IMapper imapper, ICustomer Customer)
        {
            _imapper = imapper;
            _Customer = Customer;
        }

        public int AddCustomerData(Customers CustomerModel, string CustomerNo)
        {
            return _Customer.AddCustomerData(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.TblCustomer>(CustomerModel),CustomerNo);
        }

        public List<Customer> AutoIncrementCustomerNo()
        {
            return _imapper.Map<List<Customer>>(_Customer.GetCustomer());
        }

        public Customers CustomerById(string CustomerNo)
        {
            return _imapper.Map<Customers>(_Customer.CustomerById(CustomerNo));
        }

        public int DeleteCustomer(string CustomerNo)
        {
            return _Customer.DeleteCustomer(CustomerNo);
        }

        public List<Customer> GetCustomer()
        {
            return _imapper.Map<List<Customer>>(_Customer.GetCustomer());
        }

        public int UpdateCustomer(Customers CustomerModel, string CustomerNo, string CustomerName)
        {
            return _Customer.UpdateCustomer(_imapper.Map<Customer_Invoice_Payment_Management.DataLogic.DatabaseModel.TblCustomer>(CustomerModel), CustomerNo, CustomerName);
        }
    }
}
