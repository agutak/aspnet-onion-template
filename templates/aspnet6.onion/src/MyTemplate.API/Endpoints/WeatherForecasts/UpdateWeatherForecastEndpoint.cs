using MyTemplate.API.Controllers.WeatherForecasts.Contracts;

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

        var weathterForecastDto = MapFrom(model);

        await service.UpdateWeatherForecastAsync(weathterForecastDto, cancellation);
        return Results.Ok();
    }

    private static WeatherForecastUpdateDto MapFrom(WeatherForecastUpdateModel model)
    {
        return new WeatherForecastUpdateDto(
            model.Id,
            model.Date,
            model.TemperatureC,
            model.Summary);
    }
}
