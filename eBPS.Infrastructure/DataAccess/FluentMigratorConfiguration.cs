using eBPS.Infrastructure.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eBPS.Infrastructure.DataAccess
{
    public static class FluentMigratorConfiguration
    {
        public static void AddFluentMigrator(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddFluentMigratorCore()
                    .ConfigureRunner(runner => runner
                        .AddSqlServer()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(typeof(AddMigrations).Assembly).For.Migrations())
                    .AddLogging(lb => lb.AddFluentMigratorConsole());
        }
    }
}
