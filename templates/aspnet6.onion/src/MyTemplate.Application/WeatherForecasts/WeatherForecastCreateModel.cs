namespace MyTemplate.Application.WeatherForecasts;

public record WeatherForecastCreateModel(
    DateTime Date,
    int TemperatureC,
    string? Summary);
