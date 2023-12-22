using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace MyTemplate.Persistence.MongoDb.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterMongoDbPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(
            configuration.GetSection(MongoDbSettings.ConfigSectionName));

        services.AddSingleton(sp =>
        {
            var options = (sp.GetService<IOptions<MongoDbSettings>>()?.Value)
                ?? throw new InvalidOperationException("MongoDbSettings configuration section is not defined.");

            var clientSettings = MongoClientSettings.FromConnectionString(options.ConnectionString);
            clientSettings.LinqProvider = LinqProvider.V3;
            return new MongoClient(clientSettings);
        });

        services.AddSingleton(sp =>
        {
            var options = (sp.GetService<IOptions<MongoDbSettings>>()?.Value) 
                ?? throw new InvalidOperationException("MongoDbSettings configuration section is not defined.");

            var mongoClient = sp.GetRequiredService<MongoClient>();

            return mongoClient.GetDatabase(options.DatabaseName);
        });

        MongoSerializationMappings.Register();

        services.AddScoped<IMongoDbContext, MongoDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IWeatherForecastsRepository, WeatherForecastsRepository>();
    }
}
