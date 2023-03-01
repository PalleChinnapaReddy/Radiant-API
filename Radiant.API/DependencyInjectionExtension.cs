using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Radiant.Business;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Radiant.API
{
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterAll(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

            var contact = new OpenApiContact
            {
                Name = "Radiant ManPower Management",
                Url = new Uri("https://www.techefolks.com/"),
                Email = "a.com"

            };

            var license = new OpenApiLicense
            {
                Name = $"© {DateTime.Now.Year} Radiant Manpower Management",
                Url = new Uri("https://www.techefolks.com/")
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Radiant-API", new OpenApiInfo
                {
                    Version = "Radiant-API",
                    Title = $"Radiant-API API v1",

                    Contact = contact,
                    License = license
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header e.g., <b>Bearer dXNlcm5hbWU6cGFzc3dvcmQ=</b> or Basic Authentication header e.g., <b>Basic dXNlcm5hbWU6cGFzc3dvcmQ=</b>"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                                new string[] {}

                        }
                    });

                c.CustomSchemaIds((type) => type.FullName);
                c.EnableAnnotations();
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            services.AddSwaggerGenNewtonsoftSupport();

            services.RegisterBusinessLayer();
            return services;
        }
    }
}
