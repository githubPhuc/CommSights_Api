using CommSights_Api.Abstractions.Services;
using Microsoft.OpenApi.Models;

namespace CommSights_Api.Main.DIExtensions
{
    public static class SystemSwagger
    {
        public static IServiceCollection AddSystemSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Auth Api",
                    Version = "v1",
                });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type= ReferenceType.SecurityScheme,
                                Id ="Bearer",
                            }
                        },
                        new string[]{}
                    }
                });
            });
            return services;
        }
    }
}
