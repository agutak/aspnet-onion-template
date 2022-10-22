namespace MyTemplate.Persistence.MongoDb.Repositories;

internal class WeatherForecastsRepository : Repository<WeatherForecast, Guid>, IWeatherForecastsRepository
{
    private const string _collectionName = "WeatherForecasts";

    public WeatherForecastsRepository(IMongoDbContext dbContext)
        : base(dbContext, _collectionName)
    {
    }

    public override async Task UpdateAsync(WeatherForecast entity, CancellationToken cancellation)
    {
        // For Clusters only
        //var session = await _dbContext.GetSessionAsync(cancellation);

        var filter = Builders<WeatherForecast>.Filter.Where(x => x.EntityId.Equals(entity.EntityId));

        var updateDefinition = Builders<WeatherForecast>
            .Update
            .Set(x => x.Date, entity.Date)
            .Set(x => x.TemperatureC, entity.TemperatureC)
            .Set(x => x.Summary, entity.Summary);

        await _collection.UpdateOneAsync(
            //session,
            filter,
            updateDefinition,
            new UpdateOptions { IsUpsert = true},
            cancellation);
    }
}
