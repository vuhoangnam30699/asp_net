using Microsoft.EntityFrameworkCore;
using NLog;
using WebApiLogging.Loggings;
using WebApiLogging.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add DB context
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<T2301E_SEM3Context>(x => x.UseSqlServer(connectionString));

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
