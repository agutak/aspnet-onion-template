#if (UseMinimalAPIs)
using MyTemplate.API.Endpoints.WeatherForecasts;
#endif
using MyTemplate.API.GrpcServices.WeatherForecasting;
using MyTemplate.Application.Extensions;
#if (MongoDBPersistence)
using MyTemplate.Persistence.MongoDb.Extensions;
#endif
#if (MsSqlPersistence)
using MyTemplate.Persistence.MsSql.Extensions;
#endif

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

// Add services to the container.
#if (UseControllers)
builder.Services.AddControllers();
#endif

builder.Services.AddGrpc();

#if (UseRest)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endif

#if (MsSqlPersistence)
builder.Services.RegisterMsSqlPersistenceServices(builder.Configuration);
#endif
#if (MongoDBPersistence)
builder.Services.RegisterMongoDbPersistenceServices(builder.Configuration);
#endif

builder.Services.RegisterApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

#if (UseRest)
if (app.Environment.IsEnvironment("Local") ||
    app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#endif

#if (UseMinimalAPIs)
app.RegisterWeatherForecastsEndpoints();
#elif (UseControllers)
app.MapControllers();
#endif

app.MapGrpcService<WeatherForecastsGrpcService>();

app.Run();
