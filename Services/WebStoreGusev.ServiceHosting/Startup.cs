using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebStoreGusev.Clients.Values;
using WebStoreGusev.DAL;
using WebStoreGusev.Domain.Entities.Identity;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Infrastructure.Services.InCookies;
using WebStoreGusev.Infrastructure.Services.InMemory;
using WebStoreGusev.Infrastructure.Services.InSQL;
using WebStoreGusev.Interfaces.Api;
using WebStoreGusev.Interfaces.Services;
using WebStoreGusev.Services.Products.InMemory;

namespace WebStoreGusev.ServiceHosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddDbContext<WebStoreContext>(options => options
               .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<WebStoreContext>()
               .AddDefaultTokenProviders();

            // необязательно
            services.Configure<IdentityOptions>(options =>
            {
                // password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                // lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // user settings
                options.User.RequireUniqueEmail = true;
            });


            services.AddSingleton<IEmployeesServices, InMemoryEmployeeService>();
            services.AddScoped<IProductService, SqlProductService>();
            services.AddScoped<ICartService, CookieCartService>();
            services.AddScoped<IOrdersService, SqlOrdersService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
