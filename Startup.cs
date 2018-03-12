using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MusiCoLab2.Services;
using MusiCoLab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;
using System.Web.Http;

namespace MusiCoLab2
{
    public class Startup
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    var corsAttr = new EnableCorsAttribute("*", "*", "*");
        //    config.EnableCors(corsAttr);
        //}
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            var config = builder.SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: false);
            Configuration = config.Build();
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            var connection = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<UserContext>(options =>
                {
                    options.UseSqlServer(connection);
                });
            services.AddScoped<IProjectService, ProjectService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>

               builder.AllowAnyOrigin()
               
               );

            app.UseMvc(routes =>
            {
                
                routes.MapRoute(
                   name: "default",
                   template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
