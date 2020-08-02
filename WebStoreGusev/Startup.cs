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
            #region Подключение MVC к проекту

            services.AddMvc();

            #endregion

            #region Подключение EntityFramework к проекту

            services.AddDbContext<WebStoreContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #endregion

            #region Подключение Identity

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

            // необязательно
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

            #region Подключение action-фильтра ко всем контроллерам

            //services.AddMvc(options =>
            //{
            //    // 1
            //    options.Filters.Add(typeof(SimpleActionFilter));

            //    // 2 
            //    options.Filters.Add(new SimpleActionFilter());
            //});

            #endregion

            #region Добавляем разрешение зависимости

            // время жизни сервиса - время работы приложения 
            services.AddSingleton<IEmployeesServices, InMemoryEmployeeService>();
            //services.AddSingleton<IProductService, InMemoryProductService>();
            services.AddScoped<IProductService, SqlProductService>();
            // время жизни сервиса - время одного запроса
            //services.AddScoped<IEmployeesServices, InMemoryEmployeeService>();
            
            // подключение куков
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CookieCartService>();

            #endregion
        }

        // конвеер выполнения запросов
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // исползование статических файлов
            app.UseStaticFiles();

            app.UseRouting();

            // использование аутентификации
            app.UseAuthentication();
            // использование авторизации
            app.UseAuthorization();

            // Метод Map позволяет перехватывать запрос по адресу
            app.Map("/index", CustomIndexHandler);

            app.UseMiddleware<TokenMiddleware>();

            // Метод Use может как прекращать, так и продолжать обработку
            // конвейера запросов
            UseSample(app);

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

            // app.UseMvcWithDefaultRoute();

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

            app.UseWelcomePage();

            // Метод Run прекращает обработку конвейера запросов
            RunSample(app);
        }

        #region Методы демонстрации Map Run Use

        private void RunSample(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Привет из конвейера обработки запроса (метод app.Run())");
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
