namespace MyTemplate.Persistence.MsSql.Context.EntitiesConfigurations;

internal sealed class WeatherForecastEntityConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    private const string _keyPropertyName = "_id";

    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.ToTable("WeatherForecasts");

        builder.Property<int>(_keyPropertyName);

        builder.HasKey(_keyPropertyName);
    }
}
