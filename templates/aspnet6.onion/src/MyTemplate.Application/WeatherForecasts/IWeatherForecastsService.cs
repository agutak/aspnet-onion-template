namespace MyTemplate.Application.WeatherForecasts;

public interface IWeatherForecastsService
{
    Task<Guid> CreateWeatherForecastAsync(WeatherForecastCreateModel model);

    Task<IEnumerable<WeatherForecastVm>> GetWeatherForecastsAsync(CancellationToken cancellation);

    Task<WeatherForecastVm?> GetWeatherForecastAsync(Guid id, CancellationToken cancellation);

    Task UpdateWeatherForecastAsync(WeatherForecastUpdateModel model, CancellationToken cancellation);
}
