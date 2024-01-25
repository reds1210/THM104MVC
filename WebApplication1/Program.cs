using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using WebApplication1.Models.Entity;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option => 
                {
                    option.LoginPath = "/account/login";
                    option.AccessDeniedPath = "/home/deny";
                    option.ExpireTimeSpan = TimeSpan.FromSeconds(30);
                });


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IDiscountService, DiscountService>();
            builder.Services.AddDbContext<NorthwindContext>(opt =>
               opt.UseSqlServer(builder.Configuration.GetConnectionString("NorthWind"))
            );

            builder.Services.AddScoped<IEmailService, EmailService>();

            //NET6
            //builder.Services.AddSqlServer<NorthwindContext>("");



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.Map("/hello", x =>
            //{
            //    x.Run(async c => await c.Response.WriteAsync("9487"));
            //});
            app.UseAuthentication();
            app.UseAuthorization();


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
