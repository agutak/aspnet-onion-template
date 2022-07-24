namespace MyTemplate.Persistence.MongoDb.Context.EntitiesConfigurations;

internal class WeatherForecastSerializationMapping : BaseSerializationMapping<WeatherForecast>
{
    public WeatherForecastSerializationMapping()
    {
        ClassMap = ConfigureMappings;
    }

    private void ConfigureMappings(BsonClassMap<WeatherForecast> bsonClassMap)
    {
        bsonClassMap.AutoMap();
        
        bsonClassMap.UnmapProperty(x => x.TemperatureF);
    }
}
