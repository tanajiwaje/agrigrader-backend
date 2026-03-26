


using Microsoft.EntityFrameworkCore;
using AgriGrader.Infrastructure.Data;
using AgriGrader.Core.Interfaces;
using AgriGrader.Infrastructure;
using AgriGrader.Infrastructure.Repositories;
using AgriGrader.Application.Services;
using AgriGrader.Application.Interfaces;
using AgriGrader.Infrastructure.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers(); // Enables API Controllers

// Register Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with SQL Server connection
builder.Services.AddDbContext<AgrigraderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories (DI)
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISellerService, SellerService>();

builder.Services.AddScoped<IBuyerRepository,BuyerRepository>();
builder.Services.AddScoped<IBuyerService, BuyerService>();

builder.Services.AddScoped<ICommodityRepository, CommodityRepository>();
builder.Services.AddScoped<ICommodityService, CommodityService>();

builder.Services.AddScoped<ISubCommodityRepository, SubCommodityRepository>();
builder.Services.AddScoped<ISubCommodityService, SubCommodityService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();




builder.Services.AddScoped<IFirebaseOtpService, FirebaseOtpService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseCors("AllowAngular");
// Use Swagger only in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseCors("AllowAngular");
app.UseAuthorization();    // Handle [Authorize] attributes (if used)

app.MapControllers();      // Enable attribute routing for controllers

app.Run();
