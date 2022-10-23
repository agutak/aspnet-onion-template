namespace MyTemplate.Application.WeatherForecasts;

public interface IWeatherForecastsService
{
    Task<Guid> CreateWeatherForecastAsync(WeatherForecastCreateDto model);

    Task<IEnumerable<WeatherForecastReturnDto>> GetWeatherForecastsAsync(CancellationToken cancellation);

    Task<WeatherForecastReturnDto?> GetWeatherForecastAsync(Guid id, CancellationToken cancellation);

    Task UpdateWeatherForecastAsync(WeatherForecastUpdateDto model, CancellationToken cancellation);
}
