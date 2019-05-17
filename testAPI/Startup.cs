using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API
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
            services.AddDbContext<LibraryContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                )
            );

            // GOOGLE SIGN IN

            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.Authority = "https://myaccount.google.com/";
                options.Audience = "211560243540-0eicjiisai5u7cgv9qjdp71ahf0e4tvq.apps.googleusercontent.com";
            });
            
            /*
            services.AddAuthentication().AddGoogle(googleOptions => {
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });
            */

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LibraryContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            DBInitializer.Initialize(context);

            // CORS

            app.UseCors(options =>
            options.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

            //app.UseHttpsRedirection();

            app.UseAuthentication();
            
            app.UseMvc();
            
        }
    }
}
