using MyTemplate.API.GrpcServices.WeatherForecasting;
using MyTemplate.Application.Extensions;
#if (MongoDBPersistence)
using MyTemplate.Persistence.MongoDb.Extensions;
#endif
#if (MsSqlPersistence)
using MyTemplate.Persistence.MsSql.Extensions;
#endif

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGrpc();

#if (MsSqlPersistence)
builder.Services.RegisterMsSqlPersistenceServices(builder.Configuration);
#endif
#if (MongoDBPersistence)
builder.Services.RegisterMongoDbPersistenceServices(builder.Configuration);
#endif

builder.Services.RegisterApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<WeatherForecastsGrpcService>();

await app.RunAsync();
