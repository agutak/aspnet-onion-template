namespace MyTemplate.Domain.UnitTests.Helpers;

internal static class WeatherForecastHelpers
{
    public static WeatherForecast CreateWeatherForecast(
        Guid? entityId = null,
        DateTime? date = null,
        int? temperatureC = null,
        string? summary = null)
    {
        entityId ??= Guid.NewGuid();
        date ??= DateTime.Now;
        temperatureC ??= 20;
        summary ??= "Test summary";

        return new WeatherForecast(entityId.Value, date.Value, temperatureC.Value, summary);
    }
}
