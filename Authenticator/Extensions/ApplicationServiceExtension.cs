using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Authenticator.Services;
using Authenticator.Helpers;

namespace Authenticator.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", builder =>
                        builder.WithOrigins("*")   //WithOrigins("https://dominio.com")
                        .WithMethods("GET", "POST", "PUT", "PACTH")          //WithMethods("GET","POST")
                        .AllowAnyHeader());        //WithHeaders("accept","content-type")
                });

        public static void AddAplicacionServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuration from AppSettings
            services.Configure<JWT>(configuration.GetSection("JWT"));
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer("Bearer", o =>
            //    {
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = configuration["JWT:Issuer"],
            //            ValidAudience = configuration["JWT:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
            //        };
            //    });
        }

        public static void AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autenticación de Token JWT - Ingresar la palabra Bearer seguida de un [Espacio] colocar el token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"

                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer",

                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                    });
            });
        }

        public static void ConfigureRateLimitiong(this IServiceCollection services)
        {
            services.AddMemoryCache();
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            //services.AddInMemoryRateLimiting();

            //services.Configure<IpRateLimitOptions>(options =>
            //{
            //    options.EnableEndpointRateLimiting = true;
            //    options.StackBlockedRequests = false;
            //    options.HttpStatusCode = 429;
            //    options.RealIpHeader = "X-Real-IP";
            //    options.QuotaExceededMessage = "Has realizado demaciadas peticiones en poco tiempo";
            //    options.GeneralRules = new List<RateLimitRule>
            //    {
            //        new RateLimitRule
            //        {
            //            Endpoint ="*",
            //              Limit = 5,
            //            Period = "60s"

            //        }
            //    };
            //});


        }
    }
}
