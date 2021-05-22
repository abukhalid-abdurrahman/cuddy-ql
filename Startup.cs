using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyBusiness.DataAccess.Repositories;
using FamilyBusiness.Database;
using FamilyBusiness.Database.Models;
using FamilyBusiness.Queries;
using FamilyBusiness.Schemas;
using FamilyBusiness.Types;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FamilyBusiness
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
            services.AddControllers();

            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IFamilyRepository, FamilyRepository>();
            
            services.AddDbContext<FamilyContext>(o => 
                o.UseSqlite(Configuration.GetConnectionString("FamilyDb")));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<FamilyQuery>();
            services.AddSingleton<FamilyType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new FamilySchema(new FuncDependencyResolver(t => sp.GetService(t))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FamilyContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            db.EnsureSeedData();
        }
    }
}
