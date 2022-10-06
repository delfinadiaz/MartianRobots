using MartianRobots.Domain.Interfaces;
using MartianRobots.Infrastructure.Persistence.Contexts;
using MartianRobots.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MartianRobots.Infrastructure.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration )
        {
            var defaultConnectionString = string.Empty;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            }
            else
            {
                // Use connection string provided at runtime by Heroku.
                var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
                var userPassSide = connectionUrl.Split("@")[0];
                var hostSide = connectionUrl.Split("@")[1];
                var hostAndPort = hostSide.Split("/")[0];

                var user = userPassSide.Split(":")[0];
                var password = userPassSide.Split(":")[1];
                var host = hostAndPort.Split(":")[0];
                var port = hostAndPort.Split(":")[1];
                var database = hostSide.Split("/")[1].Split("?")[0];

                defaultConnectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";
            }

            services.AddDbContext<MartianRobotsDbContext>(options =>
                    options.UseNpgsql(defaultConnectionString)
                );

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<MartianRobotsDbContext>();
            //dbContext.Database.Migrate();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMarsRepository, MarsRepository>();
            services.AddScoped<IRobotRepository, RobotRepository>();

            return services;
        }
    }
}
