using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using Customer_Invoice_Payment_Management.Model.Common;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Invoice_Payment_Management.DataLogic.Concrete
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
                    DashboardDetails.Add(data); 
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return DashboardDetails;
        }


        public List<Chart> DisplayChart()
        {
            List<Chart> DashboardChart = new List<Chart>();
            try
            {

                using (var dbcontext = new CustomerReportContext())
                {
                    Chart chdb;

                    foreach (var chartdb in dbcontext.TblInvoices.ToList())
                    {
                        chdb = new Chart();

                        Boolean Flag = false;

                        foreach (var chdashboard in DashboardChart.ToList())
                        {
                            if (chdashboard.MonthAndYearDate.Month == chartdb.InvoiceDate.Month && chdashboard.MonthAndYearDate.Year == chartdb.InvoiceDate.Year)
                            {
                                chdashboard.ChartSales += chartdb.InvoiceAmount;
                                Flag = true;
                            }
                        }

                        if (Flag == false)
                        {
                            chdb.MonthAndYearDate = new DateTime(chartdb.InvoiceDate.Year, chartdb.InvoiceDate.Month, 01);
                            chdb.ChartSales = chartdb.InvoiceAmount;
                            DashboardChart.Add(chdb);
                        }
                    }

                    foreach (var chartdb in dbcontext.TblPayment.ToList())
                    {
                        chdb = new Chart();

                        Boolean Flag = false;

                        foreach (var chdashboard in DashboardChart.ToList())
                        {
                            if (chdashboard.MonthAndYearDate.Month == chartdb.PaymentDate.Month && chdashboard.MonthAndYearDate.Year == chartdb.PaymentDate.Year)
                            {
                                chdashboard.ChartPayment += chartdb.PaymentAmount;
                                Flag = true;
                            }
                        }

                        if (Flag == false)
                        {
                            chdb.MonthAndYearDate = new DateTime(chartdb.PaymentDate.Year, chartdb.PaymentDate.Month, 01);
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

        public int Editprofile(User UserModel, string UserName, int UserId)
        {
            List<Userdata> Items = new List<Userdata>();

            int returnVal = 0;
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    Userdata get;
                    foreach (var it in dBContext.User)
                    {
                        get = new Userdata();
                        get.UserId = it.UserId;
                        get.FirstName = it.FirstName;
                        get.LastName = it.LastName;
                        get.UserName = it.UserName;
                        get.Password = it.Password;
                        get.Dob = it.Dob;
                        get.Gender = it.Gender;
                        get.Usertype = it.Usertype;
                        get.Region = it.Region;
                        get.ModifyDate = DateTime.Now;
                        Items.Add(get);
                    }

                    User emp = new User();
                    //Add record

                    emp = dBContext.User.FirstOrDefault(asd => asd.UserId == UserModel.UserId);
                    if (emp != null)
                    {
                        emp.UserId = UserModel.UserId;
                        emp.FirstName = UserModel.FirstName;
                        emp.LastName = UserModel.LastName;
                        emp.UserName = UserModel.UserName;
                        emp.Password = UserModel.Password;
                        emp.Dob = UserModel.Dob;
                        emp.Gender = UserModel.Gender;
                        emp.Usertype = UserModel.Usertype;
                        emp.Region = UserModel.Region;
                        emp.ModifyDate = DateTime.Now;
                        dBContext.User.Update(emp);
                        UserId = emp.UserId;
                        UserName = emp.UserName;
                    }

                    bool username = Items.Any(asd => asd.UserName == UserName);
                    bool usernameexist = Items.Any(asd => (asd.UserId == UserId) && (asd.UserName == UserName));
                    if (usernameexist == true)
                    {
                        returnVal = dBContext.SaveChanges();
                    }
                    else if (username == true)
                    {
                        returnVal = -1;
                    }
                    else
                    {
                        returnVal = dBContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnVal;
        }

        public User GetEditprofileById(int UserId)
        {
            User Cust = new User();
            try
            {
                using (var dBContext = new CustomerReportContext())
                {
                    var dep = dBContext.User.Where(x => x.UserId == UserId).SingleOrDefault();

                    if (dep != null)
                    {
                        Cust.UserId = dep.UserId;
                        Cust.FirstName = dep.FirstName;
                        Cust.LastName = dep.LastName;
                        Cust.UserName = dep.UserName;
                        Cust.Password = dep.Password;
                        Cust.Dob = dep.Dob;
                        Cust.Gender = dep.Gender;
                        Cust.Usertype = dep.Usertype;
                        Cust.Region = dep.Region;
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
