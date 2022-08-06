namespace MyTemplate.API.Endpoints.WeatherForecasts;

public class GetWeatherForecastEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        Guid id,
        IWeatherForecastsService service,
        CancellationToken cancellation)
    {
        var result = await service.GetWeatherForecastAsync(id, cancellation);

        var responseModel = MapFrom(result);

        return result is null
            ? Results.NotFound()
            : Results.Ok(responseModel);
    }

    private static WeatherForecastViewModel? MapFrom(WeatherForecastReturnDto? model)
    {
        return model is null
            ? null
            : new WeatherForecastViewModel(
                model.Id,
                model.Date,
                model.TemperatureC,
                model.TemperatureF,
                model.Summary);
    }
}
