using MyTemplate.Application.WeatherForecasts;

namespace MyTemplate.API.Endpoints.WeatherForecasts;

public class UpdateWeatherForecastEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        Guid id,
        WeatherForecastUpdateModel model,
        IWeatherForecastsService service,
        CancellationToken cancellation)
    {
        if (id != model.Id)
            return Results.BadRequest();

        await service.UpdateWeatherForecastAsync(model, cancellation);
        return Results.Ok();
    }
}
