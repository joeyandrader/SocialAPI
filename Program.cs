using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedeSocialAPI.src.AutoMapper;
using RedeSocialAPI.src.Base.DB;
using RedeSocialAPI.src.Base.Ioc;
using RedeSocialAPI.src.Base.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Load AppSettings
AppSettings.LoadSettings(builder.Configuration);

//Load Injection Dependencie
Ioc.InjectionDependencie(builder.Services);

//AutoMapper
IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//connectionSQL
builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(AppSettings.SQLConnectionString));

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
