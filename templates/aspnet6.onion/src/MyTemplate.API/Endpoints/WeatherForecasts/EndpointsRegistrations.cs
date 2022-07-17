using MyTemplate.Application.WeatherForecasts;

namespace MyTemplate.API.Endpoints.WeatherForecasts;

public static partial class EndpointsRegistrations
{
    public static void RegisterWeatherForecastsEndpoints(this WebApplication app)
    {
        app
            .MapGet("/weatherforecasts", GetAllWeatherForecastsEndpoint.ExecuteAsync)
            .WithName("GetWeatherForecasts")
            .WithTags("WeatherForecasts")
            .Produces<IEnumerable<WeatherForecastVm>>();

        app
            .MapGet("/weatherforecasts/{id}", GetWeatherForecastEndpoint.ExecuteAsync)
            .WithName("GetWeatherForecast")
            .WithTags("WeatherForecasts")
            .Produces<WeatherForecastVm>();
    }
}

