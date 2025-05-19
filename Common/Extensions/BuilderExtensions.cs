using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MeterAPI.Models;
using System.Text;
using Serilog;

namespace MeterAPI.Common.Extensions;

public static class BuilderExtensions
{
    public static WebApplicationBuilder AddArchitectures(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(name: "v1", new OpenApiInfo()
            {
                Version = "v1",
                Title = "Meter API",
                Description = "Web API para consultar e atualizar dados referente a controle de consumo dos medidores inteligente remotamente."
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "O token precisara estar no cabecalho das requisicoes para realizar a autenticacao da seguinte maneira: \r\n\r\n Bearer + Token."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
        Array.Empty<string>()
        }
        });

        });
        builder.Services.AddDbContext<AppDbContext>();

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
                
        });
        return builder;
    }

    public static WebApplicationBuilder AddToken(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["TokenJWT:Issuer"],
                ValidAudience = builder.Configuration["TokenJWT:Audience"],
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenJWT:Secret"]!))
            };
        });
        builder.Services.AddAuthorization();

        return builder;
    }

    //public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    //{
    //    builder.Host.UseSerilog((context, services, loggerConfig) =>
    //    {
    //        loggerConfig
    //            .ReadFrom.Configuration(context.Configuration) // Lê configurações do appsettings.json
    //            .WriteTo.Console() // Registra logs no console
    //            .WriteTo.File(
    //                path: "logs/log-.txt", // Caminho do arquivo de log
    //                rollingInterval: RollingInterval.Day, // Criação de um novo arquivo por dia
    //                retainedFileCountLimit: 7, // Limita a quantidade de arquivos para 7
    //                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}" // Formato de saída
    //            );
    //    });

    //    return builder;
    //}
}
