using Contatos.Data;
using Contatos.Data.Repositories;
using Contatos.Models.Interfaces;
using Contatos.Services;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Configurations
{
    public static class InfraConfig
    {
        public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
        {

            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connection));

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactServices, ContactService>();

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultCorsPolicy", policy =>
                {
                    if (environment.IsDevelopment())
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    }
                    else
                    {
                        var allowedOrigins = configuration.GetSection("Origens").Get<string[]>();

                        if (allowedOrigins != null && allowedOrigins.Length > 0)
                        {
                            policy.WithOrigins(allowedOrigins)
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                        }
                    }
                });
            });

            return services;
        }
    }
}
