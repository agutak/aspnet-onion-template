namespace MyTemplate.Application.WeatherForecasts;

public class WeatherForecastsService : IWeatherForecastsService
{
    private readonly string[] _summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<IEnumerable<WeatherForecastVm>> GetWeatherForecastsAsync(
        CancellationToken cancellation)
    {
        await Task.Delay(200, cancellation);

        return Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecastVm
                (
                    DateTime.Now.AddDays(index),
                    Random.Shared.Next(-20, 55),
                    _summaries[Random.Shared.Next(_summaries.Length)]
                ))
            .ToArray();
    }
}
