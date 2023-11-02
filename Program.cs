using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RedeSocialAPI.src.AutoMapper;
using RedeSocialAPI.src.Base.Contracts.Service;
using RedeSocialAPI.src.Base.DB;
using RedeSocialAPI.src.Base.Ioc;
using RedeSocialAPI.src.Base.Middlewares;
using RedeSocialAPI.src.Base.Utils;
using RedeSocialAPI.src.Services;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Social API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT auth"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });

    // Habilita comentario no Swagger atraves do <summary></summary>
    //
    // USE a config abaixo em .csproj em <PropertyGroup></PropertyGroup>
    // ====================================================================
    //  <GenerateDocumentationFile>true</GenerateDocumentationFile>
    //	<NoWarn>$(NoWarn); 1591 </NoWarn>
    // ====================================================================
    // Dessa forma habilitado o comentario no swagger
    //
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    opt.IncludeXmlComments(xmlPath);
});


//Load AppSettings
AppSettings.LoadSettings(builder.Configuration);

//Load Injection Dependencie
Ioc.InjectionDependencie(builder.Services);

//AutoMapper
IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Auth Mode
//Authenticate Service
var key = Encoding.ASCII.GetBytes(AppSettings.JwtKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//connectionSQL
builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(AppSettings.SQLConnectionString));

builder.Services.AddControllers();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "MyCorsPolicyName",
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });

});


builder.Services.AddTransient<JwtMiddleware>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContextService, UserContextService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Permite mostrar arquivos staticos
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Public\img")),
    RequestPath = new PathString("/public/img")
});

app.UseRouting();
app.UseAuthentication(); // add Auth
app.UseCors("MyCorsPolicyName");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<JwtMiddleware>();

app.Run();
