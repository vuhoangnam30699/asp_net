using Logging_and_Monitoring.Loggings;
using Logging_and_Monitoring.Models;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get DBContext from appsettings
var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
builder.Services.AddDbContext<T2301eSem3Context>(x => x.UseSqlServer(connectionString));

//Add Log configuration
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

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
