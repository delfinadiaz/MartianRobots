using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace MartianRobots.Infrastructure.Persistence.Contexts
{
    public class MartianRobotsDbContextFactory : IDesignTimeDbContextFactory<MartianRobotsDbContext>
    {
        public MartianRobotsDbContext CreateDbContext(string[] args)
        {

            // Get environment
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MartianRobotsDbContext>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

            return new MartianRobotsDbContext(optionsBuilder.Options);
        }
    }
}
