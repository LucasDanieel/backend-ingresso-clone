using System;
using brevo_csharp.Client;
using Ingresso.Infra.Data.ContextDb;
using Ingresso.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

Configuration.Default.ApiKey.Add("api-key", builder.Configuration["BrevoApi:ApiKey"]);

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

//var redis = ConnectionMultiplexer.Connect(builder.Configuration["MySettings:ConnetionRedis"]);
//builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", build =>
{
    build.WithOrigins(builder.Configuration["MySettings:FrontEndUrl"]).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
}));

var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

var app = builder.Build();

app.UseRouting();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
