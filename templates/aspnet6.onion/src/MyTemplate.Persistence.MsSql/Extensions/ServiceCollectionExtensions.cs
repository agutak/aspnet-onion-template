using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyTemplate.Persistence.MsSql.Extensions;

public static class ServiceCollectionExtensions
{
    public const string DbConnectionStringName = "MyDbConnectionString";

    public static void RegisterPersistenceServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString(DbConnectionStringName);

        if (dbConnectionString is null || dbConnectionString.Length <= 0)
            throw new ArgumentNullException(nameof(dbConnectionString), "DB connection string cannot be null.");

        services.AddDbContext<MyDbContext>(builder =>
            builder.UseSqlServer(
                dbConnectionString,
                options => options
                    .MigrationsAssembly("MyTemplate.Persistence.MsSql.Migrations")
                    .MigrationsHistoryTable("__EFMigrationsHistory", MyDbContext.DEFAULT_SCHEMA)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
