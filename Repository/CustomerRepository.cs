using System;
using System.Collections.Generic;
using CrudReportGenerate.Model.Common;
using System.Linq;
using System.Threading.Tasks;
using CrudReportGenerate.Model.Entity;
using CrudReportGenerate.Interface;

namespace CrudReportGenerate.Repository
{
    public class CustomerRepository : ICustomer
    {
        public List<Model.Common.Customer> GetCustomer()
        {
            List<Model.Common.Customer> Items = new List<Model.Common.Customer>();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Common.Customer cust;
                    foreach (var it in dBContext.TblCustomer)
                    {
                        cust = new Model.Common.Customer();
                        cust.CustomerNo = it.CustomerNo;
                        cust.CustomerName = it.CustomerName;
                        Items.Add(cust);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Items;
        }

        public int AddCustomerData(Model.Common.Customer CustomerModel, string CustomerNo)
        {
            List<Model.Common.Customer> Items = new List<Model.Common.Customer>();

            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Common.Customer get;
                    foreach (var it in dBContext.TblCustomer)
                    {
                        get = new Model.Common.Customer();
                        get.CustomerNo = it.CustomerNo;
                        get.CustomerName = it.CustomerName;
                        Items.Add(get);
                    }

                    TblCustomer Cust;
                    //Add record
                    Cust = new TblCustomer();
                    Cust.CustomerNo = CustomerModel.CustomerNo;
                    Cust.CustomerName = CustomerModel.CustomerName;
                    
                    CustomerNo = Cust.CustomerNo;

                    bool CustNo = Items.Any(asd => asd.CustomerNo == CustomerNo);
                    if (CustNo == true)
                    {
                        returnVal = -1;
                    }

                    if (CustNo == false)
                    {
                        dBContext.TblCustomer.Add(Cust);
                        returnVal = dBContext.SaveChanges();
                    }

                    //returnVal = dBContext.SaveChanges();  


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;
        }

        public int UpdateCustomer(Customer CustomerModel, string CustomerNo, string CustomerName)
        {
            List<Customer> Items = new List<Customer>();

            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Customer get;
                    foreach (var it in dBContext.TblCustomer)
                    {
                        get = new Customer();
                        get.CustomerNo = it.CustomerNo;
                        get.CustomerName = it.CustomerName;
                        Items.Add(get);
                    }

                    Model.Entity.TblCustomer Cust = new Model.Entity.TblCustomer();
                    //Add record

                    Cust = dBContext.TblCustomer.FirstOrDefault(asd => asd.CustomerNo == CustomerModel.CustomerNo);
                    Cust.CustomerNo = CustomerModel.CustomerNo;
                    Cust.CustomerName = CustomerModel.CustomerName;
                    dBContext.TblCustomer.Update(Cust);

                    returnVal = dBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;
        }

        public int DeleteCustomer(string CustomerNo)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Entity.TblCustomer emp = new Model.Entity.TblCustomer(); 
                    Model.Entity.TblInvoices inv = new Model.Entity.TblInvoices();


                    //Add record
                    {
                        emp = dBContext.TblCustomer.FirstOrDefault(asd => asd.CustomerNo == CustomerNo);
                        inv = dBContext.TblInvoices.FirstOrDefault(asd => asd.CustomerNo == CustomerNo);
                        if (inv == null)
                        {
                            if (emp != null)
                            {
                                dBContext.TblCustomer.Remove(emp);
                                returnVal = dBContext.SaveChanges();
                            }
                        }
                        else
                        {
                            returnVal = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;
        }


        public Customer CustomerById(string CustomerNo)
        {
            Customer Cust = new Customer();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    var dep = dBContext.TblCustomer.Where(x => x.CustomerNo == CustomerNo).SingleOrDefault();

                    if (dep != null)
                    {
                        Cust.CustomerNo = dep.CustomerNo;
                        Cust.CustomerName = dep.CustomerName;
                    }
                    return Cust;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
