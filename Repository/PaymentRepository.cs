using CrudReportGenerate.Interface;
using CrudReportGenerate.Model.Common;
using CrudReportGenerate.Model.Entity;
using CrudReportGenerate.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Repository
{
    public class PaymentRepository : IPayment
    {
        public List<Model.Common.Payment> GetPayment()
        {
            List<Model.Common.Payment> Items = new List<Model.Common.Payment>();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Common.Payment Pay;
                    foreach (var it in dBContext.TblPayment)
                    {
                        Pay = new Model.Common.Payment();
                        Pay.PaymentNo = it.PaymentNo;
                        Pay.PaymentDate = it.PaymentDate;
                        Pay.PaymentAmount = it.PaymentAmount;
                        Pay.InvoiceNo = it.InvoiceNo;
                        Items.Add(Pay);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Items;
        }

        public int AddPaymentData(Model.Common.Payment PaymentModel, string PaymentNo)
        {
            List<Payment> Items = new List<Payment>();

            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Common.Payment get;
                    foreach (var it in dBContext.TblPayment)
                    {
                        get = new Model.Common.Payment();
                        get.PaymentNo = it.PaymentNo;
                        get.InvoiceNo = it.InvoiceNo;
                        get.PaymentDate = it.PaymentDate;
                        get.PaymentAmount = it.PaymentAmount;
                        Items.Add(get);
                    }

                    TblPayment Cust;
                    //Add record
                    Cust = new TblPayment();
                    Cust.PaymentNo = PaymentModel.PaymentNo;
                    Cust.InvoiceNo = PaymentModel.InvoiceNo;
                    Cust.PaymentDate = PaymentModel.PaymentDate;
                    Cust.PaymentAmount = PaymentModel.PaymentAmount;
                    dBContext.TblPayment.Add(Cust);
                    PaymentNo = Cust.PaymentNo;

                    bool Invoicexist = Items.Any(asd => asd.PaymentNo == PaymentNo);
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

        public int UpdatePayment(Payment PaymentModel, string PaymentNo, string PaymentName)
        {
            List<Payment> Items = new List<Payment>();

            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Payment get;
                    foreach (var it in dBContext.TblPayment)
                    {
                        get = new Payment();
                        get.PaymentNo = it.PaymentNo;
                        get.InvoiceNo = it.InvoiceNo;
                        get.PaymentDate = it.PaymentDate;
                        get.PaymentAmount = it.PaymentAmount;
                        Items.Add(get);
                    }

                    Models.Entity.TblPayment Cust = new Models.Entity.TblPayment();
                    //Add record

                    Cust = dBContext.TblPayment.FirstOrDefault(asd => asd.PaymentNo == PaymentModel.PaymentNo);
                    //emp = new Employes();
                    Cust.PaymentNo = PaymentModel.PaymentNo;
                    Cust.InvoiceNo = PaymentModel.InvoiceNo;
                    Cust.PaymentDate = PaymentModel.PaymentDate;
                    Cust.PaymentAmount = PaymentModel.PaymentAmount;
                    dBContext.TblPayment.Update(Cust);
                    PaymentNo = Cust.PaymentNo;

                    bool Invoicexist = Items.Any(asd => asd.PaymentNo == PaymentNo);
                    if (Invoicexist == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        returnVal = dBContext.SaveChanges();
                    }
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

        public int DeletePayment(string PaymentNo)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Models.Entity.TblPayment emp = new Models.Entity.TblPayment();
                    Customer DeleteItem = new Customer();
                    //Add record
                    {
                        emp = dBContext.TblPayment.FirstOrDefault(asd => asd.PaymentNo == PaymentNo);
                        if (emp != null)
                        {
                            //emp = new Employes();
                            //emp.Id = EmployesModel.Id;
                            dBContext.TblPayment.Remove(emp);
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

        public Payment PaymentById(string PaymentNo)
        {
            Payment Cust = new Payment();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    var dep = dBContext.TblPayment.Where(x => x.PaymentNo == PaymentNo).SingleOrDefault();

                    if (dep != null)
                    {
                        Cust.PaymentNo = dep.PaymentNo;
                        Cust.InvoiceNo = dep.InvoiceNo;
                        Cust.PaymentDate = dep.PaymentDate;
                        Cust.PaymentAmount = dep.PaymentAmount;
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
