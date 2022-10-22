namespace MyTemplate.Application.WeatherForecasts.Dtos;

public record WeatherForecastCreateDto(
    DateTime Date,
    int TemperatureC,
    string? Summary);
