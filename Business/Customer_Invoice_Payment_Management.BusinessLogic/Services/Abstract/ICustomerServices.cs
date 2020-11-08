using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface ICustomerServices
    {
        public List<Customer> GetCustomer();
        public int AddCustomerData(Customers CustomerModel, string CustomerNo);
        public int UpdateCustomer(Customers CustomerModel, string CustomerNo, string CustomerName);
        public int DeleteCustomer(string CustomerNo);
        public Customers CustomerById(string CustomerNo);
        public List<Customer> AutoIncrementCustomerNo();
    }
}
