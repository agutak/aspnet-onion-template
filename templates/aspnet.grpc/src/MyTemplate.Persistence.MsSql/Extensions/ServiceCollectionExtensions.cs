using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyTemplate.Persistence.MsSql.Extensions;

public static class ServiceCollectionExtensions
{
    public const string DbConnectionStringName = "MyTemplateDb";

    public static void RegisterMsSqlPersistenceServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString(DbConnectionStringName);

        if (dbConnectionString is null || dbConnectionString.Length <= 0)
            throw new InvalidOperationException("DB connection string cannot be null.");

        services.AddDbContext<MyTemplateContext>(builder =>
            builder.UseSqlServer(
                dbConnectionString,
                options => options.EnableRetryOnFailure()));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IWeatherForecastsRepository, WeatherForecastsRepository>();
    }
}
