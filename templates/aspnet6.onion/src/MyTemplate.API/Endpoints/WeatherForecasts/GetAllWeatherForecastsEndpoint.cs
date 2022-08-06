using MyTemplate.API.Controllers.WeatherForecasts.Contracts;

namespace MyTemplate.API.Endpoints.WeatherForecasts;

public class GetAllWeatherForecastsEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        IWeatherForecastsService service,
        CancellationToken cancellation)
    {
        var results = await service.GetWeatherForecastsAsync(cancellation);

        var responseModels = MapFrom(results);

        return Results.Ok(responseModels);
    }

    private static IEnumerable<WeatherForecastViewModel>? MapFrom(IEnumerable<WeatherForecastReturnDto>? models)
    {
        return models is null
            ? Enumerable.Empty<WeatherForecastViewModel>()
            : models
                .Select(model =>
                    new WeatherForecastViewModel(
                        model.Id,
                        model.Date,
                        model.TemperatureC,
                        model.TemperatureF,
                        model.Summary))
                .ToList();
    }
}
