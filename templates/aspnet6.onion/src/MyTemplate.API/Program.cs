using MyTemplate.API.Endpoints.WeatherForecasts;
using MyTemplate.Application.Extensions;
using MyTemplate.Persistence.MongoDb.Extensions;
using MyTemplate.Persistence.MsSql.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.RegisterMsSqlPersistenceServices(builder.Configuration);
builder.Services.RegisterMongoDbPersistenceServices(builder.Configuration);

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
