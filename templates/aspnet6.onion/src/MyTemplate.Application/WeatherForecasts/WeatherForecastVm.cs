namespace MyTemplate.Application.WeatherForecasts;

public record WeatherForecastVm(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
