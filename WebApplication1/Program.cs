using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NLog.Web;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using WebApplication1.Filters;
using WebApplication1.Middleware;
using WebApplication1.Models.Entity;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/account/login";
                    option.AccessDeniedPath = "/home/deny";
                    option.ExpireTimeSpan = TimeSpan.FromSeconds(30);
                })
                .AddGoogle(option =>
                {
                    //option.CallbackPath = "/account/GoogleResponse";
                    option.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                    option.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                });


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IDiscountService, DiscountService>();
            builder.Services.AddDbContext<NorthwindContext>(opt =>
               opt.UseSqlServer(builder.Configuration.GetConnectionString("NorthWind"))
            );

            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<TimerActionFilter>();


            //NET6
            //builder.Services.AddSqlServer<NorthwindContext>("");

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.Use(async (context, next) =>
            //{
            //    // 處理HTTP請求
            //    await context.Response.WriteAsync("start");
            //    await next(); // 呼叫管道中的下一個中間件
            //    await context.Response.WriteAsync("end");

            //    // 處理HTTP響應
            //});

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseRiverCrab();

            app.MapControllerRoute(
               name: "areas",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

    }
}
