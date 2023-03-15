using Microsoft.EntityFrameworkCore;
using ProcurementApi.Controllers;
using ProcurementApi.Controllers.Interface;
using ProcurementApi.Repositories;
using ProcurementApi.Repositories.Interfaces;
using ProcurementApi.Services;
using ProcurementApi.Services.Interfaces;
using PurchaseRepository = ProcurementApi.Repositories.PurchaseRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<AppDbContext>(o => o.UseNpgsql());

builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMaterialService, IMaterialService>();
builder.Services.AddScoped<IMaterialController, MaterialController>();

builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IPurchaseController, PurchaseController>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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