using Application.Utils;
using Infrastructure.Ioc;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AppSettings
AppSettings.LoadSettings(builder.Configuration);

//Dependency Injection
Ioc.LoadDependencyInjection(builder.Services);
//Connection with postgres dapper
builder.Services.AddScoped<IDbConnection>(conn => new NpgsqlConnection(AppSettings.ConnectionString));

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
