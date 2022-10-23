using Microsoft.Extensions.DependencyInjection;

namespace MyTemplate.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastsService, WeatherForecastsService>();
    }
}
