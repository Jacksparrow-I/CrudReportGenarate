using System;
using System.Collections.Generic;
using Customer_Invoice_Payment_Management.Model.Common;
using System.Linq;
using System.Threading.Tasks;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;

namespace Customer_Invoice_Payment_Management.DataLogic.Concrete
{
    public class CustomerRepository : ICustomer
    {
        string Val;

        public List<Customer> GetCustomer()
        {
            List<Customer> Items = new List<Customer>();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Customer cust;
                    foreach (var it in dBContext.TblCustomer)
                    {
                        cust = new Customer();
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

        public int AddCustomer(TblCustomer CustomerModel, string CustomerNo)
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
                        get.CreatedBy = it.CreatedBy;
                        get.CreatedDate = it.CreatedDate;
                        Items.Add(get);
                    }

                    TblCustomer Cust;
                    //Add record
                    Cust = new TblCustomer();
                    Cust.CustomerNo = CustomerModel.CustomerNo;
                    Cust.CustomerName = CustomerModel.CustomerName;
                    Cust.CreatedBy = CustomerModel.CreatedBy;
                    Cust.CreatedDate = DateTime.Now;
                    CustomerNo = Cust.CustomerNo;

                    bool CustNo = Items.Any(asd => asd.CustomerNo == CustomerNo);
                    if (CustNo == true)
                    {
                        returnVal = -1;
                    }

                    if (CustNo == false)
                    {
                        dBContext.TblCustomer.Add(Cust);
                        //returnVal = dBContext.SaveChanges();
                    }

                    //Add AutoIncreament

                    AutoIncrement Auto = new AutoIncrement();

                    int Num = Convert.ToInt32(Cust.CustomerNo.Substring(1));
                    string Num1 = Convert.ToString(Num);
                    foreach (var val in dBContext.AutoIncrement.ToList())
                    {
                        Auto.AutoCustomerNo = Num;
                        Auto.AutoInvoiceNo = val.AutoInvoiceNo;
                        Auto.AutoPaymentNo = val.AutoPaymentNo;
                    }

                    var rows = from cu in dBContext.AutoIncrement select cu;

                    foreach (var row in rows)
                    {
                        if (row != null)
                        {
                            dBContext.AutoIncrement.Remove(row);
                            //dbcontext.savechanges();
                        }
                    }

                    dBContext.AutoIncrement.Add(Auto);

                    returnVal = dBContext.SaveChanges();  

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;
        }

        public int UpdateCustomer(TblCustomer CustomerModel, string CustomerNo, string CustomerName)
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
                        get.ModifyBy = it.ModifyBy;
                        get.ModifyDate = DateTime.Now;
                        Items.Add(get);
                    }

                    TblCustomer Cust = new TblCustomer();
                    //Add record

                    Cust = dBContext.TblCustomer.FirstOrDefault(asd => asd.CustomerNo == CustomerModel.CustomerNo);
                    Cust.CustomerNo = CustomerModel.CustomerNo;
                    Cust.CustomerName = CustomerModel.CustomerName;
                    Cust.ModifyBy = CustomerModel.ModifyBy;
                    Cust.ModifyDate = DateTime.Now;
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
                    TblCustomer emp = new TblCustomer(); 
                    TblInvoices inv = new TblInvoices();


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

        public List<Customer> AutoIncrementCustomerNo()
        {
            List<Customer> Cust = new List<Customer>();
            List<Customer> Cust1 = new List<Customer>();
            using (var dBContext = new CustomerReportContext())
            {
                Customer data;
                foreach (var Customer in dBContext.TblCustomer.ToList())
                {
                    data = new Customer();
                    data.CustomerNo = Customer.CustomerNo;
                    Cust.Add(data);
                }

                Customer data2;
                foreach (var auto in dBContext.AutoIncrement.ToList())
                {
                    data2 = new Customer();
                    int no;
                    no = Convert.ToInt32(auto.AutoCustomerNo);
                    no += 1;
                    Val = "C" + no.ToString("D5");

                    AutoBack:
                    bool No = Cust.Any(x => x.CustomerNo == Val);
                    if (No == true)
                    {
                        no += 1;
                        Val = "C" + no.ToString("D5");
                        goto AutoBack;

                    }
                    data2.CustomerNo = 'C' + Val.Substring(1); ;
                    Cust1.Add(data2);
                }

            }

            return Cust1;

        }

        public TblCustomer CustomerById(string CustomerNo)
        {
            TblCustomer Cust = new TblCustomer();
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
