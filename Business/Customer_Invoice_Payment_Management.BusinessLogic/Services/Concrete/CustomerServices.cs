using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomer _Customer;
        public CustomerServices(ICustomer Customer)
        {
            _Customer = Customer;
        }
        
        public int AddCustomer(TblCustomer CustomerModel, string CustomerNo)
        {
            return _Customer.AddCustomer(CustomerModel, CustomerNo);
        }

        public List<Customer> AutoIncrementCustomerNo()
        {
            return _Customer.AutoIncrementCustomerNo();
        }

        public TblCustomer GetCustomerById(string CustomerNo)
        {
            return _Customer.GetCustomerById(CustomerNo);
        }

        public int DeleteCustomer(string CustomerNo)
        {
            return _Customer.DeleteCustomer(CustomerNo);
        }

        public List<Customer> GetCustomers()
        {
            return _Customer.GetCustomers();
        }

        public int UpdateCustomer(TblCustomer CustomerModel, string CustomerNo, string CustomerName)
        {
            return _Customer.UpdateCustomer(CustomerModel, CustomerNo, CustomerName);
        }
    }
}
