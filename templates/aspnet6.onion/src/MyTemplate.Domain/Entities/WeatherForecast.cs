namespace MyTemplate.Domain.Entities;

public class WeatherForecast : Entity<Guid>
{
    public WeatherForecast(DateTime date, int temperatureC, string? summary)
    {
        EntityId = Guid.NewGuid();
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public WeatherForecast(Guid entityId, DateTime date, int temperatureC, string? summary)
        : this(date, temperatureC, summary)
    {
        EntityId = entityId;
    }

    public DateTime Date { get; private set; }
    public int TemperatureC { get; private set; }
    public string? Summary { get; private set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public void UpdateDetails(DateTime date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
}
