using MyTemplate.API.Endpoints.WeatherForecasts;
using MyTemplate.Application.Extensions;
#if (MongoDBPersistence)
using MyTemplate.Persistence.MongoDb.Extensions;
#endif
#if (MsSqlPersistence)
using MyTemplate.Persistence.MsSql.Extensions;
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if (MsSqlPersistence)
builder.Services.RegisterMsSqlPersistenceServices(builder.Configuration);
#endif
#if (MongoDBPersistence)
builder.Services.RegisterMongoDbPersistenceServices(builder.Configuration);
#endif

builder.Services.RegisterApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsEnvironment("Local") ||
    app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterWeatherForecastsEndpoints();

app.Run();
