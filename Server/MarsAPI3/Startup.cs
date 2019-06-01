using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsAPI3.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MarsAPI3
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
            // DEPLOYMENT IN GOOGLE CLOUD

            /*
            services.AddDbContext<MarsContext>(
                options => options.UseMySQL(
                    Configuration.GetConnectionString("DefaultConnection")
                )
                //options => options.UseMy
            );
            */

            // GOOGLE SIGN IN

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.Authority = "https://myaccount.google.com/";
                options.Audience = "211560243540-0eicjiisai5u7cgv9qjdp71ahf0e4tvq.apps.googleusercontent.com";
            });

            services.AddDbContext<MarsContext>(
               options => options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")
               )
           );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MarsContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            DBInitialiser.Initialize(context);

            // CORS

            app.UseCors(options =>
            options.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
