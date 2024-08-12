using BE.Application.Common.Interfaces;
using BE.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BE.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        //.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "v1",
                    new OpenApiInfo()
                    {
                        Title = "AI-Career-Match Web API",
                        Version = "1",
                        Description = "Through this API you can access TherapAI's details",
                        Contact = new OpenApiContact()
                        {
                            Email = "ai-career-match@gmail.com",
                            Name = "AI-Career-Match",
                           
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "© 2024 AI-Career-Match Tüm Hakları Saklıdır",
                          
                        }
                    });

                setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });

            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();


            services.AddAuthentication(options =>
            {
                //doğrulama olarak jwt token kullanmak istediğimize dair bilgi veriyoruz
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(o =>
              {
                  o.RequireHttpsMetadata = false;
                  o.SaveToken = false;
                  o.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero,
                      ValidIssuer = configuration["JwtSettings:Issuer"],
                      ValidAudience = configuration["JwtSettings:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!))
                  };

              });
            return services;
        }
    }
}
