using Microsoft.AspNetCore.Authentication.Negotiate;
using ZipCodeValidation.Application;
using ZipCodeValidation.Domain.Interfaces;
using ZipCodeValidation.Infrastructure.Strategies; 

namespace ZipCodeValidation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            /* builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                .AddNegotiate();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });
            */ 
            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000", "http://localhost:5173") // React dev servers
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });
            // DEPENDENCY 
            //builder.Services.AddScoped<ZipCodeValidationService>();

            // Register strategy implementation
            builder.Services.AddScoped<IZipCodeValidationStrategy, USZipCodeValidationStrategy>();

            // Register service
            builder.Services.AddScoped<IZipCodeValidationService, ZipCodeValidationService>();

            // Register validator if you want it injected separately
            builder.Services.AddScoped<IZipCodeValidator,ZipCodeValidator>();


            var app = builder.Build();
            app.UseCors("AllowReactApp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
