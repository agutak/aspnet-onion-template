namespace MyTemplate.Persistence.MsSql.Context.EntitiesConfigurations;

internal class WeatherForecastEntityConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.ToTable("WeatherForecasts");
    }
}
