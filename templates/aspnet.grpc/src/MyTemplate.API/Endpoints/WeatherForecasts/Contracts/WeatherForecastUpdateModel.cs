namespace MyTemplate.API.Endpoints.WeatherForecasts.Contracts;

public record WeatherForecastUpdateModel(
    Guid Id,
    DateTime Date,
    int TemperatureC,
    string? Summary);
