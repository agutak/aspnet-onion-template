using MyTemplate.API.Endpoints.WeatherForecasts.Contracts;

namespace MyTemplate.API.Endpoints.WeatherForecasts;

public class CreateWeatherForecastEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        WeatherForecastCreateModel model,
        IWeatherForecastsService service)
    {
        var weathterForecastDto = MapFrom(model);

        var id = await service.CreateWeatherForecastAsync(weathterForecastDto);
        return Results.Ok(id);
    }

    private static WeatherForecastCreateDto MapFrom(WeatherForecastCreateModel model)
    {
        return new WeatherForecastCreateDto(
            model.Date,
            model.TemperatureC,
            model.Summary);
    }
}
