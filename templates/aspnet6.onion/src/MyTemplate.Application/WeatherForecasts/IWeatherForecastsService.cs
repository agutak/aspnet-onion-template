namespace MyTemplate.Application.WeatherForecasts;

public interface IWeatherForecastsService
{
    Task<IEnumerable<WeatherForecastVm>> GetWeatherForecastsAsync(CancellationToken cancellation);
}
