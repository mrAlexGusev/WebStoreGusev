using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            // ����� ����� ������� - ����� ������ �������
            //services.AddScoped<IEmployeesServices, InMemoryEmployeeService>();

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

            // ����� Map ��������� ������������� ������ �� ������
            app.Map("/index", CustomIndexHandler);

            app.UseMiddleware<TokenMiddleware>();

            // ����� Use ����� ��� ����������, ��� � ���������� ���������
            // ��������� ��������
            UseSample(app);

            app.UseRouting();

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
