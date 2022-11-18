namespace MyTemplate.Persistence.MsSql.Repositories;

internal class WeatherForecastsRepository : Repository<WeatherForecast, Guid>, IWeatherForecastsRepository
{
    public WeatherForecastsRepository(MyTemplateContext dbContext) : base(dbContext)
    {
    }
}
