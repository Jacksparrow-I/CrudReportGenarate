using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract
{
    public interface ICustomerServices
    {
        public List<Customer> GetCustomers();
        public int AddCustomer(TblCustomer CustomerModel, string CustomerNo);
        public int UpdateCustomer(TblCustomer CustomerModel, string CustomerNo, string CustomerName);
        public int DeleteCustomer(string CustomerNo);
        public TblCustomer GetCustomerById(string CustomerNo);
        public List<Customer> AutoIncrementCustomerNo();
    }
}
