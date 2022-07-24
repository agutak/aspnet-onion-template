using MyTemplate.Application.WeatherForecasts;

namespace MyTemplate.API.Endpoints.WeatherForecasts;

public class CreateWeatherForecastEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        WeatherForecastCreateModel model,
        IWeatherForecastsService service)
    {
        var id = await service.CreateWeatherForecastAsync(model);
        return Results.Ok(id);
    }
}
