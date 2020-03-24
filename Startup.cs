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


namespace MusiCoLab2
{
    public class Startup
    {

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                   // .WithOrigins("http://localhost:8080")
                   .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            var connection = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<UserContext>(options =>
                {
                    options.UseMySQL(connection);
                });
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors("AllowSpecificOrigin");

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                   name: "default",
                   template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
