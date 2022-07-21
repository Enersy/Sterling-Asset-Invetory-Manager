using CleanAssetApi.API;
using CleanAssetApi.Application.Interfaces;
using CleanAssetApi.Application.Services;
using CleanAssetApi.Infrastructure.Data;
using CleanAssetApi.Infrastructure.DBInterfaces;
using CleanAssetApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.
builder.Services.ConfigureLoggerService();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<APIDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("CleanAssetApi.API")));

builder.Services.AddScoped<ILaptopService, LaptopService>();
builder.Services.AddScoped<ILaptopRepository, LaptopRepository>();
builder.Services.AddScoped<IDesktopService, DesktopService>();
builder.Services.AddScoped<IDesktopRepository, DesktopRepository>();
builder.Services.AddScoped<IFakeDesktopService,FakeDesktopService>();
builder.Services.AddScoped<IFakeDesktopRepository,FakeDesktopRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
