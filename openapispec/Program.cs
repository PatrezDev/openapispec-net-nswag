using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;
using static openapispec.Controllers.WeatherForecastController;

namespace openapispec
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            //.Microsoft.AspnetCore.OpenApi
            builder.Services.AddOpenApi();

            //NSwag
            builder.Services.AddOpenApiDocument();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                //.Microsoft.AspnetCore.OpenApi
                app.MapOpenApi();

                //NSwag
                app.UseOpenApi();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/minimal-api-approach", () =>
            {
                return "Hello World!";
            }).Produces<Dictionary<AuthErrorType, ErrorDetail>>().WithOpenApi();

            app.Run();
        }
    }
}
