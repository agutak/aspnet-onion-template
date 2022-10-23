namespace MyTemplate.Application.WeatherForecasts.Dtos;

public record WeatherForecastReturnDto(
    Guid Id,
    DateTime Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary);
