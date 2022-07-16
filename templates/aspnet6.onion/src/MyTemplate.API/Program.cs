using MyTemplate.Application.Extensions;
using MyTemplate.Application.WeatherForecasts;
using MyTemplate.Persistence.MsSql.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterPersistenceServices(builder.Configuration);

builder.Services.RegisterApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Local") ||
    app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/weatherforecast", async (
    IWeatherForecastsService service,
    CancellationToken cancellation) =>
{
    return await service.GetWeatherForecastsAsync(cancellation);
})
.WithName("GetWeatherForecast");

app.Run();
