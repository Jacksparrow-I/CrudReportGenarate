using System;
using System.Collections.Generic;
using CrudReportGenerate.Model.Common;
using System.Linq;
using System.Threading.Tasks;
using CrudReportGenerate.Model.Entity;
using CrudReportGenerate.Interface;
using CrudReportGenerate.Models.Entity;

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
                    dBContext.TblCustomer.Add(Cust);
                    CustomerNo = Cust.CustomerNo;

                    bool Invoicexist = Items.Any(asd => asd.CustomerNo == CustomerNo);
                    if (Invoicexist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
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

                    Models.Entity.TblCustomer Cust = new Models.Entity.TblCustomer();
                    //Add record

                    Cust = dBContext.TblCustomer.FirstOrDefault(asd => asd.CustomerNo == CustomerModel.CustomerNo);
                    //emp = new Employes();
                    Cust.CustomerNo = CustomerModel.CustomerNo;
                    Cust.CustomerName = CustomerModel.CustomerName;
                    dBContext.TblCustomer.Update(Cust);
                    //CustomerNo = Cust.CustomerNo;
                    //CustomerName = Cust.CustomerName;

                    //bool departmentsame = Items.Any(asd => asd.CustomerName == CustomerName);
                    //bool departmentexist = Items.Any(asd => (asd.CustomerNo == CustomerNo) && (asd.CustomerName == CustomerName));
                    //if (departmentexist == true)
                    //{
                    //    returnVal = dBContext.SaveChanges();
                    //}
                    //else if (departmentsame == true)
                    //{
                    //    returnVal = -1;
                    //}
                    //else
                    //{
                    //    returnVal = dBContext.SaveChanges();
                    //}

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
                    Models.Entity.TblCustomer emp = new Models.Entity.TblCustomer();
                    Customer DeleteItem = new Customer();
                    //Add record
                    {
                        emp = dBContext.TblCustomer.FirstOrDefault(asd => asd.CustomerNo == CustomerNo);
                        if (emp != null)
                        {
                            //emp = new Employes();
                            //emp.Id = EmployesModel.Id;
                            dBContext.TblCustomer.Remove(emp);
                        }
                    }
                    returnVal = dBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;
        }
    }
}
