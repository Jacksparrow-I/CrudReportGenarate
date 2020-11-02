using CrudReportGenerate.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Interface
{
    public interface ICustomer
    {
        public List<Customer> GetCustomer(); 
        public int AddCustomerData(Customer CustomerModel, string CustomerNo);
        public int UpdateCustomer(Customer CustomerModel, string CustomerNo, string CustomerName);
        public int DeleteCustomer(string CustomerNo);
        public Customer CustomerById(string CustomerNo);
        public List<Customer> AutoIncrementCustomerNo();
    }
}
