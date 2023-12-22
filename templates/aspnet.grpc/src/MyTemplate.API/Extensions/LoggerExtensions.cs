namespace MyTemplate.API.Extensions;

public static partial class LoggerExtensions
{
    [LoggerMessage(
        EventId = 10001,
        Level = LogLevel.Warning,
        Message = "Weather Forecast with ID:{id} was not found.")]
    public static partial void WeatherForecastNotFound(
        this ILogger logger,
        Guid id);
}
