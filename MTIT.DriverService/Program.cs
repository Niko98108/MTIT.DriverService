using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTIT.DriverService.Data;
using MTIT.DriverService.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MTITDriverServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MTITDriverServiceContext") ?? throw new InvalidOperationException("Connection string 'MTITDriverServiceContext' not found.")));

// Add services to the container.

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

app.MapDriverEndpoints();

app.Run();
