using AutoMapper;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.BusinessModel;
using Customer_Invoice_Payment_Management.DataLogic.DatabaseModel;
using Customer_Invoice_Payment_Management.Model.Common;

namespace Stridely.ARTool.API.AutoMapper.Profiles
{
    /// <summary>
    /// This class is used for mapping object of databse and tenant entity to model.
    /// </summary>
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<Customers, TblCustomer>().ReverseMap();
            CreateMap<Customer, TblCustomer>().ReverseMap();

            CreateMap<Userdata, User>().ReverseMap();
            CreateMap<user, User>().ReverseMap();

            CreateMap<Invoices, TblInvoices>().ReverseMap();
            CreateMap<Invoice, TblInvoices>().ReverseMap();

            CreateMap<Payments, TblPayment>().ReverseMap();
            CreateMap<Payment, TblPayment>().ReverseMap();

            CreateMap<Autoincrement, TblCustomer>().ReverseMap();

            CreateMap<Dashboards, Dashboard>().ReverseMap();
            CreateMap<Charts, Chart>().ReverseMap();
            CreateMap<Report, Reports>().ReverseMap();
        }
    }
}
