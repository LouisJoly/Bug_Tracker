using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BugTracker.Api.Tests
{
    public class DatabaseConnectionTest
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;

        public DatabaseConnectionTest()
        {
            _services = new ServiceCollection();
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        [Fact]
        public async Task TestDatabaseConnection()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("BugTrackerDb");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("La chaîne de connexion n'est pas configurée");
                }

                using var context = new DbContext(new DbContextOptionsBuilder()
                    .UseNpgsql(connectionString)
                    .Options);

                await context.Database.CanConnectAsync();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Erreur de connexion à la base de données : {ex.Message}");
            }
        }
    }
}
