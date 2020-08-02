using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebStoreGusev.DAL;
using WebStoreGusev.Domain.Entities;
using WebStoreGusev.Infrastructure;
using WebStoreGusev.Infrastructure.Interfaces;
using WebStoreGusev.Infrastructure.Services;

namespace WebStoreGusev
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
 
        public void ConfigureServices(IServiceCollection services)
        {
            #region ����������� MVC � �������

            services.AddMvc();

            #endregion

            #region ����������� EntityFramework � �������

            services.AddDbContext<WebStoreContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region ����������� Identity

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();

            // �������������
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

            // �������������
            //services.ConfigureApplicationCookie(options =>
            //{
            //    // cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.Expiration = TimeSpan.FromDays(150);
            //    options.LoginPath = "/Account/Login";
            //    options.LogoutPath = "/Account/Logout";
            //    options.AccessDeniedPath = "/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});

            #endregion

            #region ����������� action-������� �� ���� ������������

            //services.AddMvc(options =>
            //{
            //    // 1
            //    options.Filters.Add(typeof(SimpleActionFilter));

            //    // 2 
            //    options.Filters.Add(new SimpleActionFilter());
            //});

            #endregion

            #region ��������� ���������� �����������

            // ����� ����� ������� - ����� ������ ���������� 
            services.AddSingleton<IEmployeesServices, InMemoryEmployeeService>();
            //services.AddSingleton<IProductService, InMemoryProductService>();
            services.AddScoped<IProductService, SqlProductService>();
            // ����� ����� ������� - ����� ������ �������
            //services.AddScoped<IEmployeesServices, InMemoryEmployeeService>();
            
            // ����������� �����
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CookieCartService>();

            #endregion
        }

        // ������� ���������� ��������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ������������ ����������� ������
            app.UseStaticFiles();

            app.UseRouting();

            // ������������� ��������������
            app.UseAuthentication();
            // ������������� �����������
            app.UseAuthorization();

            // ����� Map ��������� ������������� ������ �� ������
            app.Map("/index", CustomIndexHandler);

            app.UseMiddleware<TokenMiddleware>();

            // ����� Use ����� ��� ����������, ��� � ���������� ���������
            // ��������� ��������
            UseSample(app);

            #region ������ � ������ ������������

            //// ������ � ����������� ������� ������������
            //var helloMsg = configuration["CustomHelloWorld"];
            //// ������ � ��������� ������� ������������
            //helloMsg = configuration["Logging:LogLevel:Default"];

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync(helloMsg);
            //    });
            //});

            #endregion

            // app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                // ������ ���� MVC
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                #region �� ���������

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                #endregion

            });

            app.UseWelcomePage();

            // ����� Run ���������� ��������� ��������� ��������
            RunSample(app);
        }

        #region ������ ������������ Map Run Use

        private void RunSample(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("������ �� ��������� ��������� ������� (����� app.Run())");
            });
        }

        private void UseSample(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                bool isErorr = false;
                // ...
                if (isErorr)
                {
                    await context.Response
                        .WriteAsync("Error occured. You're in custom pipline module...");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        private void CustomIndexHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }

        #endregion


    }
}
