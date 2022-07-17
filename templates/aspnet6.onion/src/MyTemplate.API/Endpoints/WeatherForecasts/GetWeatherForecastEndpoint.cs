using MyTemplate.Application.WeatherForecasts;

namespace MyTemplate.API.Endpoints.WeatherForecasts;

public class GetWeatherForecastEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        int id,
        IWeatherForecastsService service,
        CancellationToken cancellation)
    {
        var result = await service.GetWeatherForecastAsync(id, cancellation);
        return Results.Ok(result);
    }
}
