using CrudReportGenerate.Interface;
using CrudReportGenerate.Model.Common;
using CrudReportGenerate.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudReportGenerate.Repository
{
    public class DashboardRepository : IDashboard
    {
        public List<Dashboard> GetDashboardDetails()
        {
            List<Dashboard> DashboardDetails = new List<Dashboard>();
            try
            {
                using (var dbcontext = new CustomerReportContext())
                {
                    Dashboard data = new Dashboard();
                    data.TotalCustomer = dbcontext.TblCustomer.Count();
                    data.TotalInvoice = dbcontext.TblInvoices.Count();

                    foreach (var sa in dbcontext.TblInvoices.ToList())
                    {
                        data.TotalSales += sa.InvoiceAmount;
                    }

                    foreach(var pc in dbcontext.TblPayment.ToList())
                    {
                        data.TotalPayCollection += pc.PaymentAmount;
                    }
                    //var dep = dbcontext.TblInvoices.Where(x => x.InvoiceAmount).Sum();
                    //data.TotalInvoice = dep.InvoiceAmount;
                    //data.TotalInvoice = dbcontext.TblInvoices.Count();
                    DashboardDetails.Add(data); 
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return DashboardDetails;
        }


        public List<Dashboard> DisplayChart()
        {
            List<Dashboard> DashboardChart = new List<Dashboard>();
            try
            {

                using (var dbcontext = new CustomerReportContext())
                {
                    //Dashboard data = new Dashboard();

                    //DateTime Today = DateTime.Today;
                    //var Month = (Today.Month);
                    //var Year = (Today.Year);

                    //data.ChartMonthly = dbcontext.TblCustomer.Count();

                    //data.TotalInvoice = dbcontext.TblInvoices.Count();

                    //foreach (var sa in dbcontext.TblInvoices.ToList())
                    //{
                    //    data.ChartSales += sa.InvoiceAmount;
                    //}

                    //foreach (var pc in dbcontext.TblPayment.ToList())
                    //{
                    //    data.ChartPayment += pc.PaymentAmount;
                    //}
                    //DashboardChart.Add(data);

                    Dashboard chdb;


                    foreach (var chartdb in dbcontext.TblInvoices.ToList())
                    {
                        chdb = new Dashboard();

                        Boolean Flag = false;

                        foreach (var chdashboard in DashboardChart.ToList())
                        {
                            var it1 = chdashboard.MonthAndYearDate.Date;
                            var it2 = chartdb.InvoiceDate.Date;

                            if (it1 == it2)
                            {
                                chdashboard.ChartSales += chartdb.InvoiceAmount;
                                Flag = true;
                            }
                        }

                        if (Flag == false)
                        {
                            chdb.MonthAndYearDate = chartdb.InvoiceDate;
                            chdb.ChartSales = chartdb.InvoiceAmount;
                            DashboardChart.Add(chdb);
                        }

                    }

                    foreach (var chartdb in dbcontext.TblPayment.ToList())
                    {
                        chdb = new Dashboard();

                        Boolean Flag = false;

                        foreach (var chdashboard in DashboardChart.ToList())
                        {
                            var it1 = chdashboard.MonthAndYearDate.Date;
                            var it2 = chartdb.PaymentDate.Date;

                            if (it1 == it2)
                            {
                                chdashboard.ChartPayment += chartdb.PaymentAmount;
                                Flag = true;
                            }
                        }

                        if (Flag == false)
                        {
                            chdb.MonthAndYearDate = chartdb.PaymentDate;
                            chdb.ChartPayment = chartdb.PaymentAmount;
                            DashboardChart.Add(chdb);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            DashboardChart = DashboardChart.OrderBy(asd => asd.MonthAndYearDate).ToList();


            return DashboardChart;
        }
    }
}
