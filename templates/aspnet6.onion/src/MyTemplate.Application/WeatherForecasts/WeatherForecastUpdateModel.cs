namespace MyTemplate.Application.WeatherForecasts;

public record WeatherForecastUpdateModel(
    Guid Id,
    DateTime Date,
    int TemperatureC,
    string? Summary);
