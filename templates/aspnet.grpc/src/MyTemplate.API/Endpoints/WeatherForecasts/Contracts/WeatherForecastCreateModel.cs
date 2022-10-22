namespace MyTemplate.API.Endpoints.WeatherForecasts.Contracts;

public record WeatherForecastCreateModel(
    DateTime Date,
    int TemperatureC,
    string? Summary);
