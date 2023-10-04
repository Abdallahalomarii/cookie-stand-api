using cookie_stand_api.Data;
using cookie_stand_api.Model.Interfaces;
using cookie_stand_api.Model.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace cookie_stand_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            string? connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<CookieSalmonDbContext>(options =>
            options.UseSqlServer(connString));

            builder.Services.AddTransient<ICookieStand, CookieStandService>();

   
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Cookie Salmon API",
                    Version = "v1",
                });
            });

            var app = builder.Build();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Cookie Salmon API");
                options.RoutePrefix = "";
            });

            app.MapControllers();


            app.Run();
        }
    }
}
