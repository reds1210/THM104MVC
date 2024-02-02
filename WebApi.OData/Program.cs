
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using WebApi.OData.Models.Entity;

namespace WebApi.OData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddOData(opt=> opt.Select().Filter().Expand().SetMaxTop(100).Count().OrderBy());


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<NorthwindContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("nor")));
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("forWeb", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
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
