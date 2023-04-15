using Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AnnotateAPI.Extensions;

public static class IServiceCollectionExtensions {
    public static void AddJwtAuthentication(this IServiceCollection serviceCollection, string jwtKey, string issuer, string audience) {
        serviceCollection.AddAuthentication(authOptions => {
            authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidAudience = audience,
            };
        });
    }

    public static void AddIdentity(this IServiceCollection serviceCollection) {
        serviceCollection.AddIdentity<AppUser, IdentityRole>(options => {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 5;
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AnnotateDbContext>();
    }

    public static void AddSwagger(this IServiceCollection serviceCollection) {
        serviceCollection.AddSwaggerGen(c => {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                Description = "JWT Authorization using Bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement { {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
            },
            new string[]{}
            }
            });
        });
    }
}
