using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Customer_Invoice_Payment_Management.Model.Common;
using Customer_Invoice_Payment_Management.DataLogic.Concrete;
using Customer_Invoice_Payment_Management.DataLogic.Abstract;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http.Features;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
////using CrudReportGenerate.AutoMapper;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Concrete;
using Customer_Invoice_Payment_Management.BusinessLogic.Services.Abstract;

namespace CrudReportGenarate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddControllers();
            var appSettingsSection = Configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingsSection);

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            //JWT Authentication
            var appSetting = appSettingsSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSetting.Key);

            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            ////Configure mapping profile, Auto Mapper Configurations
            //_ = services.AddSingleton(MappingConfiguration.RegisterProfiles());

            //  Swager
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer_Invoice_Payment_Management", Version = "v1" });

            });

            #region Data Access Layer
            services.AddControllers();
            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<IInvoice, InvoiceRepository>();
            services.AddScoped<IPayment, PaymentRepository>();
            services.AddScoped<IReport, ReportRepository>();
            services.AddScoped<ILogin, LoginRepository>();
            services.AddScoped<IDashboard, DashboardRepository>();
            services.AddScoped<IAuthenticate, AuthenticateRepository>();
            #endregion


            #region Business Logic Layer
            services.AddControllers();
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<IInvoiceServices, InvoiceServices>();
            services.AddScoped<IPaymentServices, PaymentServices>();
            services.AddScoped<IReportServices, ReportServices>();
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddScoped<IDashboardServices, DashbordServices>();
            services.AddScoped<IAuthenticateServices, AuthenticateServices>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
