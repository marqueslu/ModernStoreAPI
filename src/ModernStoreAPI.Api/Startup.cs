using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ModernStoreAPI.Domain.Commands.Handlers;
using ModernStoreAPI.Domain.Repositories;
using ModernStoreAPI.Domain.Services;
using ModernStoreAPI.Infra.Contexts;
using ModernStoreAPI.Infra.Repositories;
using ModernStoreAPI.Infra.Services;
using ModernStoreAPI.Infra.Transactions;

namespace ModernStoreAPI.Api
{
    public class Startup
    {   
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();

            services.AddScoped<ModernStoreAPIDataContext, ModernStoreAPIDataContext>();
            services.AddTransient<IUow, Uow>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<OrderCommandHandler, OrderCommandHandler>();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
           {
               x.AllowAnyHeader();
               x.AllowAnyMethod();
               x.AllowAnyOrigin();
           });
            app.UseMvc();
        }
    }
}
