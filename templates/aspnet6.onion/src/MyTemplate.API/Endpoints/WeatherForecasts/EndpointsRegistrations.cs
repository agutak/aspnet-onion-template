namespace MyTemplate.API.Endpoints.WeatherForecasts;

public static partial class EndpointsRegistrations
{
    public static void RegisterWeatherForecastsEndpoints(this WebApplication app)
    {
        app
            .MapPost("/weatherforecasts", CreateWeatherForecastEndpoint.ExecuteAsync)
            .WithName("CreateWeatherForecast")
            .WithTags("WeatherForecasts")
            .Produces<string>();

        app
            .MapGet("/weatherforecasts", GetAllWeatherForecastsEndpoint.ExecuteAsync)
            .WithName("GetWeatherForecasts")
            .WithTags("WeatherForecasts")
            .Produces<IEnumerable<WeatherForecastViewModel>>();

        app
            .MapGet("/weatherforecasts/{id}", GetWeatherForecastEndpoint.ExecuteAsync)
            .WithName("GetWeatherForecast")
            .WithTags("WeatherForecasts")
            .Produces<WeatherForecastViewModel>();

        app
            .MapPut("/weatherforecasts/{id}", UpdateWeatherForecastEndpoint.ExecuteAsync)
            .WithName("UpdateWeatherForecast")
            .WithTags("WeatherForecasts");
    }
}

