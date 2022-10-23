namespace MyTemplate.API.Controllers.WeatherForecasts.Contracts;

public record WeatherForecastCreateModel(
    DateTime Date,
    int TemperatureC,
    string? Summary);
