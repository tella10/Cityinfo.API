using Cityinfo.API.Context;
using Cityinfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Cityinfo.API
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IConfiguration _Configuration;
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
                //.AddMvcOptions(o =>
                //{
                //    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                //});
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();

            
            services.AddDbContext<CityInfoContext>(o =>
            {
                o.UseSqlServer(_Configuration.GetConnectionString("connectionString"));
            });

            services.AddScoped<ICityInfoRepository, CityInfoRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseMvc();

        }
    }
}
