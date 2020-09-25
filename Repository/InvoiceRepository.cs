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
    public class InvoiceRepository : IInvoice
    {
        public List<Model.Common.Invoice> GetInvoice()
        {
            List<Model.Common.Invoice> Items = new List<Model.Common.Invoice>();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Common.Invoice inv;
                    foreach (var it in dBContext.TblInvoices)
                    {
                        inv = new Model.Common.Invoice();
                        inv.InvoiceNo = it.InvoiceNo;
                        inv.CustomerNo = it.CustomerNo;
                        inv.InvoiceDate = it.InvoiceDate;
                        inv.InvoiceAmount = it.InvoiceAmount;
                        inv.PaymentDueDate = it.PaymentDueDate;
                        Items.Add(inv);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Items;
        }

        public int AddInvoiceData(Model.Common.Invoice InvoiceModel, string InvoiceNo)
        {
            List<Model.Common.Invoice> Items = new List<Model.Common.Invoice>();

            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Common.Invoice get;
                    foreach (var it in dBContext.TblInvoices)
                    {
                        get = new Model.Common.Invoice();
                        get.InvoiceNo = it.InvoiceNo;
                        get.CustomerNo = it.CustomerNo;
                        get.InvoiceDate = it.InvoiceDate;
                        get.InvoiceAmount = it.InvoiceAmount;
                        get.PaymentDueDate = it.PaymentDueDate;
                        Items.Add(get);
                    }

                    TblInvoices Cust;
                    //Add record
                    Cust = new TblInvoices();
                    Cust.InvoiceNo = InvoiceModel.InvoiceNo;
                    Cust.CustomerNo = InvoiceModel.CustomerNo;
                    Cust.InvoiceDate = InvoiceModel.InvoiceDate;
                    Cust.InvoiceAmount = InvoiceModel.InvoiceAmount;
                    Cust.PaymentDueDate = InvoiceModel.PaymentDueDate;
                    //dBContext.TblInvoices.Add(Cust);
                    InvoiceNo = Cust.InvoiceNo;

                    bool Inv = Items.Any(asd => asd.InvoiceNo == InvoiceNo);
                    if (Inv == true)
                    {
                        returnVal = -1;
                    }

                    if (Inv == false)
                    {
                        dBContext.TblInvoices.Add(Cust);
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

        public int UpdateInvoice(Invoice InvoiceModel, string InvoiceNo, string InvoiceName)
        {
            List<Invoice> Items = new List<Invoice>();

            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Invoice get;
                    foreach (var it in dBContext.TblInvoices)
                    {
                        get = new Invoice();
                        get.InvoiceNo = it.InvoiceNo;
                        get.CustomerNo = it.CustomerNo;
                        get.InvoiceDate = it.InvoiceDate;
                        get.InvoiceAmount = it.InvoiceAmount;
                        get.PaymentDueDate = it.PaymentDueDate;
                        Items.Add(get);
                    }

                    Models.Entity.TblInvoices Cust = new Models.Entity.TblInvoices();
                    //Add record

                    Cust = dBContext.TblInvoices.FirstOrDefault(asd => asd.InvoiceNo == InvoiceModel.InvoiceNo);
                    //emp = new Employes();
                    Cust.InvoiceNo = InvoiceModel.InvoiceNo;
                    Cust.CustomerNo = InvoiceModel.CustomerNo;
                    Cust.InvoiceDate = InvoiceModel.InvoiceDate;
                    Cust.InvoiceAmount = InvoiceModel.InvoiceAmount;
                    Cust.PaymentDueDate = InvoiceModel.PaymentDueDate;
                    dBContext.TblInvoices.Update(Cust);
                    InvoiceNo = Cust.InvoiceNo;

                    bool Inv = Items.Any(asd => asd.InvoiceNo == InvoiceNo);
                    if (Inv == true)
                    {
                        returnVal = -1;
                    }

                    if (Inv == false)
                    {
                        dBContext.TblInvoices.Add(Cust);
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

        public int DeleteInvoice(string InvoiceNo)
        {
            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Models.Entity.TblInvoices emp = new Models.Entity.TblInvoices();
                    Customer DeleteItem = new Customer();
                    //Add record
                    {
                        emp = dBContext.TblInvoices.FirstOrDefault(asd => asd.InvoiceNo == InvoiceNo);
                        if (emp != null)
                        {
                            //emp = new Employes();
                            //emp.Id = EmployesModel.Id;
                            dBContext.TblInvoices.Remove(emp);
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

        public Invoice InvoiceById(string InvoiceNo)
        {
            Invoice Cust = new Invoice();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    var dep = dBContext.TblInvoices.Where(x => x.InvoiceNo == InvoiceNo).SingleOrDefault();

                    if (dep != null)
                    {
                        Cust.InvoiceNo = dep.InvoiceNo;
                        Cust.CustomerNo = dep.CustomerNo;
                        Cust.InvoiceDate = dep.InvoiceDate;
                        Cust.InvoiceAmount = dep.InvoiceAmount;
                        Cust.PaymentDueDate = dep.PaymentDueDate;
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
