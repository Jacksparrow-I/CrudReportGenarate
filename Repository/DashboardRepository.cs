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
                        data.TotalSalse += sa.InvoiceAmount;
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
    }
}
