using AutoMapper;
using CodeFirst.DTOs;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get DBContext from appsettings
var connectionString = builder.Configuration.GetConnectionString("T2301EConnectionString");
builder.Services.AddDbContext<Class4DBContext>(x => x.UseSqlServer(connectionString));

// Configure AutoMapper
//var mapperConfig = new MapperConfiguration(cfg =>
//{
//    cfg.CreateMap<Student, StudentDto>();
//    cfg.CreateMap<Grade, GradeDto>();
//});
//builder.Services.AddSingleton(mapperConfig.CreateMapper());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
