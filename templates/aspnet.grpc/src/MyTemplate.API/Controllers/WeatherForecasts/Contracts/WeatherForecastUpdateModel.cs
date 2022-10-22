namespace MyTemplate.API.Controllers.WeatherForecasts.Contracts;

public record WeatherForecastUpdateModel(
    Guid Id,
    DateTime Date,
    int TemperatureC,
    string? Summary);
