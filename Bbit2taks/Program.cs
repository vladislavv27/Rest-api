﻿using Bbit2taks.Data;
using Bbit2taks.Policy;
using Bbit2taks.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace Bbit2taks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Load configuration from appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json");

            // Replace with your actual connection string
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ManagerOrResidentPolicy", policy =>
                {
                    policy.Requirements.Add(new ManagerOrResidentRequirement());
                });
            });

            builder.Services.AddSingleton<IAuthorizationHandler, ManagerOrResidentAuthorizationHandler>();

            // Configure Entity Framework DbContext with your connection string
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<HouseService>();
            builder.Services.AddScoped<ApartmentService>();
            builder.Services.AddScoped<ResidentService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();
            builder.Services.AddDistributedMemoryCache();
            // Configure JWT authentication
            builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:44476/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false, // You may need to configure this based on your setup
                                              // Other validation parameters
                };
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (!dbContext.Houses.Any()) ApplicationDbContext.SeedData(dbContext);
            }

            app.UseHttpsRedirection();




            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllers();


            app.MapControllers();


            app.Run();
        }
    }
}
