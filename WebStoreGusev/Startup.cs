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
            // ���������� MVC
            services.AddMvc();
        }

        // ������� ���������� ��������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
        }
    }
}
