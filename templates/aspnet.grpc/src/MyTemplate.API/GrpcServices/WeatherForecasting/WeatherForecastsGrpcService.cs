using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MyTemplate.API.GrpcServices.WeatherForecasting.Protos;

namespace MyTemplate.API.GrpcServices.WeatherForecasting;

public class WeatherForecastsGrpcService : WeatherForecasts.WeatherForecastsBase
{
    private readonly IWeatherForecastsService _weatherForecastsService;
    private readonly ILogger<WeatherForecastsGrpcService> _logger;

    public WeatherForecastsGrpcService(
        IWeatherForecastsService weatherForecastsService,
        ILogger<WeatherForecastsGrpcService> logger)
    {
        _weatherForecastsService = weatherForecastsService;
        _logger = logger;
    }

    public override async Task<GetWeatherForecastsResponse> GetWeatherForecasts(
        Empty request,
        ServerCallContext context)
    {
        var forecasts = await _weatherForecastsService
            .GetWeatherForecastsAsync(context.CancellationToken);

        var response = new GetWeatherForecastsResponse();

        response.Forecasts.AddRange(forecasts.Select(x => MapFrom(x)).ToList());

        return response;
    }

    public override async Task<GetWeatherForecastResponse> GetWeatherForecast(
        GetWeatherForecastRequest request,
        ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);

        var forecast = await _weatherForecastsService
            .GetWeatherForecastAsync(id, context.CancellationToken);

        var forecastResponse = MapFrom(forecast);

        if (forecast is null)
            context.Status = new Status(StatusCode.NotFound, "Not found");

        return new GetWeatherForecastResponse() { Forecast = forecastResponse };
    }

    public override async Task<CreateWeatherForecastResponse> CreateWeatherForecast(
        CreateWeatherForecastRequest request,
        ServerCallContext context)
    {
        var forecastDto = new WeatherForecastCreateDto(
            request.Date.ToDateTime(),
            request.TemperatureC,
            request.Summary);

        var id = await _weatherForecastsService.CreateWeatherForecastAsync(forecastDto);

        return new CreateWeatherForecastResponse { Id = id.ToString() };
    }

    public override async Task<Empty> UpdateWeatherForecast(
        UpdateWeatherForecastRequest request,
        ServerCallContext context)
    {
        var forecastDto = new WeatherForecastUpdateDto(
            Guid.Parse(request.Id),
            request.Date.ToDateTime(),
            request.TemperatureC,
            request.Summary);

        await _weatherForecastsService.UpdateWeatherForecastAsync(forecastDto, context.CancellationToken);

        return new Empty();
    }

    private static WeatherForecast? MapFrom(WeatherForecastReturnDto? forecast)
    {
        if (forecast is null)
            return null;

        return new WeatherForecast
        {
            Id = forecast.Id.ToString(),
            Date = Timestamp.FromDateTime(forecast.Date),
            TemperatureC = forecast.TemperatureC,
            TemperatureF = forecast.TemperatureF,
            Summary = forecast.Summary
        };
    }
}
