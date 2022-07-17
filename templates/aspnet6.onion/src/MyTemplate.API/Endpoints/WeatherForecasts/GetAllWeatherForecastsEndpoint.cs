using MyTemplate.Application.WeatherForecasts;

namespace MyTemplate.API.Endpoints.WeatherForecasts;

public class GetAllWeatherForecastsEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        IWeatherForecastsService service,
        CancellationToken cancellation)
    {
        var result = await service.GetWeatherForecastsAsync(cancellation);
        return Results.Ok(result);
    }
}
