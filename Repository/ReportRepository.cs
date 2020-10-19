using System;
using System.Collections.Generic;
using CrudReportGenerate.Model.Common;
using System.Linq;
using System.Threading.Tasks;
using CrudReportGenerate.Model.Entity;
using CrudReportGenerate.Interface;

namespace CrudReportGenerate.Repository
{
    public class ReportRepository : IReport
    {
        public List<Model.Common.Reports> GetReports()
        {
            List<Model.Common.Reports> Items = new List<Model.Common.Reports>();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Model.Common.Reports rep;
                    int i = 0;
                    foreach (var it in dBContext.TblInvoices.ToList())
                    {
                        rep = new Model.Common.Reports();
                        var Cust = dBContext.TblCustomer.FirstOrDefault(x => x.CustomerNo == it.CustomerNo);
                        rep.DateOfMonthInvoice = new DateTime(it.InvoiceDate.Year, it.InvoiceDate.Month, 15);

                        rep.DateOfMonth = rep.DateOfMonthInvoice;

                        if (Cust != null)
                        {
                            rep.CustomerNo = it.CustomerNo;
                            rep.CustomerName = Cust.CustomerName;
                        }
                        rep.NoofInvoice = 1;
                        Boolean b = false;
                        foreach (var a in Items)
                        {
                            if (a.DateOfMonthInvoice == rep.DateOfMonthInvoice && a.CustomerNo == rep.CustomerNo)
                            {
                                a.Sales = it.InvoiceAmount + a.Sales;
                                a.NoofInvoice = a.NoofInvoice + 1;
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            rep.Sales = it.InvoiceAmount;
                            i++;
                            rep.Num = i;
                            Items.Add(rep);
                        }
                    }

                    foreach (var PInvoice in dBContext.TblPayment.ToList())
                    {
                        rep = new Reports();
                        if (PInvoice != null)
                        {
                            var inv = dBContext.TblInvoices.FirstOrDefault(x => x.InvoiceNo == PInvoice.InvoiceNo);
                            rep.DateOfMonthPay = new DateTime(PInvoice.PaymentDate.Year, PInvoice.PaymentDate.Month, 15);
                            rep.DateOfMonth = rep.DateOfMonthPay;

                            if (inv != null)
                            {
                                var Cust = dBContext.TblCustomer.FirstOrDefault(x => x.CustomerNo == inv.CustomerNo);
                                if (Cust != null)
                                {

                                    rep.CustomerNo = Cust.CustomerNo;
                                    rep.CustomerName = Cust.CustomerName;
                                }
                            }
                        }
                        Boolean b = false;

                        foreach (var a in Items)
                        {
                            if ((a.DateOfMonth == rep.DateOfMonthPay || a.DateOfMonthPay == rep.DateOfMonthPay) && a.CustomerNo == rep.CustomerNo)
                            {
                                if (PInvoice != null)
                                {
                                    a.PayCollection = PInvoice.PaymentAmount + a.PayCollection;
                                }
                                b = true;
                            }
                        }
                        if (b == false)
                        {
                            if (PInvoice != null)
                            {
                                rep.PayCollection = PInvoice.PaymentAmount;
                            }
                            Items.Add(rep);
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
