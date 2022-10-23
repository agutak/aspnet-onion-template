namespace MyTemplate.Application.WeatherForecasts;

public class WeatherForecastsService : IWeatherForecastsService
{
    private readonly IWeatherForecastsRepository _weatherForecastsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WeatherForecastsService(
        IWeatherForecastsRepository weatherForecastsRepository,
        IUnitOfWork unitOfWork)
    {
        _weatherForecastsRepository = weatherForecastsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> CreateWeatherForecastAsync(WeatherForecastCreateDto model)
    {
        var weatherForecast = new WeatherForecast(
            model.Date,
            model.TemperatureC,
            model.Summary);

        await _weatherForecastsRepository
            .AddAsync(weatherForecast);

        await _unitOfWork.CompleteAsync(default);

        return weatherForecast.EntityId;
    }

    public async Task<IEnumerable<WeatherForecastReturnDto>> GetWeatherForecastsAsync(
        CancellationToken cancellation)
    {
        var weatherForecasts = await _weatherForecastsRepository
            .GetAllAsync(cancellation);

        return weatherForecasts
            .Select(x =>
                new WeatherForecastReturnDto
                (
                    x.EntityId,
                    x.Date,
                    x.TemperatureC,
                    x.TemperatureF,
                    x.Summary
                ))
            .ToArray();
    }

    public async Task<WeatherForecastReturnDto?> GetWeatherForecastAsync(
        Guid id,
        CancellationToken cancellation)
    {
        var weatherForecast = await _weatherForecastsRepository
            .GetAsync(id, cancellation);

        return weatherForecast is null
            ? default
            : new WeatherForecastReturnDto
            (
                weatherForecast.EntityId,
                weatherForecast.Date,
                weatherForecast.TemperatureC,
                weatherForecast.TemperatureF,
                weatherForecast.Summary
            );
    }

    public async Task UpdateWeatherForecastAsync(WeatherForecastUpdateDto model, CancellationToken cancellation)
    {
        var weatherForecast = await _weatherForecastsRepository
            .GetAsync(model.Id, cancellation);

        if (weatherForecast is null)
            return;

        weatherForecast.UpdateDetails(
            model.Date,
            model.TemperatureC,
            model.Summary);

        await _weatherForecastsRepository
            .UpdateAsync(weatherForecast);

        await _unitOfWork.CompleteAsync(default);
    }
}
