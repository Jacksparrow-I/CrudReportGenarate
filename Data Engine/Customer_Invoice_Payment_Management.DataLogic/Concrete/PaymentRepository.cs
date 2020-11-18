using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.Model.Common;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Invoice_Payment_Management.DataLogic.Concrete
{
    public class PaymentRepository : IPayment
    {
        string Val;
        public List<Payment> GetPayments()
        {
            List<Payment> Items = new List<Payment>();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Payment Pay;
                    foreach (var it in dBContext.TblPayment)
                    {
                        Pay = new Payment();
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

        public int AddPayment(TblPayment PaymentModel, string PaymentNo)
        {
            List<Payment> Items = new List<Payment>();
            List<Invoice> InvItems = new List<Invoice>();

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
                        get.CreatedBy = it.CreatedBy;
                        get.CreatedDate = it.CreatedDate;
                        Items.Add(get);
                    }

                    TblPayment Cust;
                    //Add record
                    Cust = new TblPayment();
                    Cust.PaymentNo = PaymentModel.PaymentNo;
                    Cust.InvoiceNo = PaymentModel.InvoiceNo;
                    Cust.PaymentDate = PaymentModel.PaymentDate;
                    Cust.PaymentAmount = PaymentModel.PaymentAmount;
                    Cust.CreatedBy = PaymentModel.CreatedBy;
                    Cust.CreatedDate = DateTime.Now;
                    dBContext.TblPayment.Add(Cust);
                    PaymentNo = Cust.PaymentNo;

                    bool Invoicexist = Items.Any(asd => asd.PaymentNo == PaymentNo);
                    if (Invoicexist == true)
                    {
                        returnVal = -1;
                    }

                    //Add AutoIncreament

                    AutoIncrement Auto = new AutoIncrement();

                    int Num = Convert.ToInt32(Cust.PaymentNo.Substring(1));
                    string Num1 = Convert.ToString(Num);
                    foreach (var val in dBContext.AutoIncrement.ToList())
                    {
                        Auto.AutoCustomerNo = val.AutoCustomerNo;
                        Auto.AutoInvoiceNo = val.AutoPaymentNo;
                        Auto.AutoPaymentNo = Num;
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

        public int UpdatePayment(TblPayment PaymentModel, string PaymentNo, string PaymentName)
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
                        get.ModifyBy = it.ModifyBy;
                        get.ModifyDate = DateTime.Now;
                        Items.Add(get);
                    }

                    TblPayment Cust = new TblPayment();
                    //Add record

                    Cust = dBContext.TblPayment.FirstOrDefault(asd => asd.PaymentNo == PaymentModel.PaymentNo);
                    Cust.PaymentNo = PaymentModel.PaymentNo;
                    Cust.InvoiceNo = PaymentModel.InvoiceNo;
                    Cust.PaymentDate = PaymentModel.PaymentDate;
                    Cust.PaymentAmount = PaymentModel.PaymentAmount;
                    Cust.ModifyBy = PaymentModel.ModifyBy;
                    Cust.ModifyDate = DateTime.Now;
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
                    TblPayment emp = new TblPayment();
                    Customer DeleteItem = new Customer();
                    //Add record
                    {
                        emp = dBContext.TblPayment.FirstOrDefault(asd => asd.PaymentNo == PaymentNo);
                        if (emp != null)
                        {
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

        public List<Payment> AutoIncrementPaymentNo()
        {
            List<Payment> Pay = new List<Payment>();

            List<Payment> Pay1 = new List<Payment>();
            using (var dBContext = new CustomerReportContext())
            {
                Payment data;
                foreach (var Payments in dBContext.TblPayment.ToList())
                {
                    data = new Payment();
                    data.PaymentNo = Payments.PaymentNo;
                    Pay.Add(data);
                }

                Payment data2;
                foreach (var auto in dBContext.AutoIncrement.ToList())
                {
                    data2 = new Payment();
                    int no;
                    no = Convert.ToInt32(auto.AutoPaymentNo);
                    no += 1;
                    Val = "P" + no.ToString("D5");

                    AutoBack:
                    bool No = Pay.Any(x => x.PaymentNo == Val);
                    if (No == true)
                    {
                        no += 1;
                        Val = "P" + no.ToString("D5");
                        goto AutoBack;

                    }
                    data2.PaymentNo = 'P' + Val.Substring(1); ;
                    Pay1.Add(data2);
                }

            }

            return Pay1;

        }

        public TblPayment GetPaymentById(string PaymentNo)
        {
            TblPayment Cust = new TblPayment();
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

        public List<Invoice> GetInvoiceDetails(string Number)
        {
            List<Invoice> Items = new List<Invoice>();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Invoice inv;
                    foreach (var it in dBContext.TblInvoices.ToList())
                    {
                        if (it.InvoiceNo == Number)
                        {
                            var customer = dBContext.TblCustomer.FirstOrDefault(x => x.CustomerNo == it.CustomerNo);

                            inv = new Invoice();
                            inv.InvoiceNo = it.InvoiceNo;
                            inv.CustomerNo = it.CustomerNo;
                            if (customer != null)
                            {
                                inv.CustomerName = customer.CustomerName;
                            }
                            inv.InvoiceDate = it.InvoiceDate;
                            inv.InvoiceAmount = it.InvoiceAmount;
                            inv.PaymentDueDate = it.PaymentDueDate;
                            Items.Add(inv);
                        }
                    }

                    foreach (var pay in dBContext.TblPayment.ToList())
                    {
                        foreach (var input in Items)
                        {
                            if (pay.InvoiceNo == Number)
                            {
                                input.PaymentAmount = input.PaymentAmount + pay.PaymentAmount;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Items;
        }
    }
}
