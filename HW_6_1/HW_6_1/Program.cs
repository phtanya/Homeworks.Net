using HW_6_1.Core;
using HW_6_1.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HW_6_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.Configure<AppConfiguration>(builder.Configuration);

            // Dependencies.

            builder.Services.AddSingleton<IVehiclesRepository, VehicleRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}