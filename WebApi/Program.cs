
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entity;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<NorthwindContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("nor")));
            builder.Services.AddCors(opt =>
            {
            opt.AddPolicy("forWeb",policy=>policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("forWeb");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
