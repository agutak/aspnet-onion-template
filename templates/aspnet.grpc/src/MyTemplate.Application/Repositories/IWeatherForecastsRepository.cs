using MyTemplate.Domain.Entities;

namespace MyTemplate.Application.Repositories;

public interface IWeatherForecastsRepository : IRepository<WeatherForecast, Guid>
{

}
