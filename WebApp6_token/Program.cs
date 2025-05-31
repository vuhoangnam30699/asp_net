using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApp6.Models;
using WebApp6.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add Db context
var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
builder.Services.AddDbContext<T2301eSem3Context>(x => x.UseSqlServer(connectionString));

//add authorization
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = ConfigurationManagerAPI.AppSetting["JWT:ValidIssuer"],
        ValidAudience = ConfigurationManagerAPI.AppSetting["JWT:ValidAudience"],
        IssuerSigningKey 
        = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("74dd743d9755d18348997845d7adb544"))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
	builder.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader();
});

app.Run();
