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
            // подключаем MVC
            services.AddMvc();
        }

        // конвеер выполнения запросов
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            #region Работа с файлом конфигурации

            //// Работа с собственной строкой конфигурации
            //var helloMsg = configuration["CustomHelloWorld"];
            //// Работа с составной строкой конфигурации
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
                // шаблон пути MVC
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                #region По умолчанию

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});

                #endregion

            });
        }
    }
}
