using Microsoft.AspNetCore.Mvc;

namespace MyTemplate.API.Controllers.WeatherForecasts;

[ApiController]
[Route("[controller]")]
public class WeatherForecastsController : ControllerBase
{
    private readonly IWeatherForecastsService _weatherForecastsService;

    public WeatherForecastsController(
        IWeatherForecastsService weatherForecastsService)
    {
        _weatherForecastsService = weatherForecastsService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateWeatherForecastAsync(
        [FromBody] WeatherForecastCreateModel model)
    {
        var weathterForecastDto = new WeatherForecastCreateDto(
            model.Date,
            model.TemperatureC,
            model.Summary);

        var id = await _weatherForecastsService
            .CreateWeatherForecastAsync(weathterForecastDto);

        return Ok(id);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherForecastViewModel>>> GetWeatherForecastsAsync(
        CancellationToken cancellation)
    {
        var results = await _weatherForecastsService
            .GetWeatherForecastsAsync(cancellation);

        var responseModels = results is null
            ? Enumerable.Empty<WeatherForecastViewModel>()
            : results
                .Select(model =>
                    new WeatherForecastViewModel(
                        model.Id,
                        model.Date,
                        model.TemperatureC,
                        model.TemperatureF,
                        model.Summary))
                .ToList();

        return Ok(responseModels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecastViewModel>> GetWeatherForecastAsync(
        [FromRoute] Guid id,
        CancellationToken cancellation)
    {
        var result = await _weatherForecastsService
            .GetWeatherForecastAsync(id, cancellation);

        var responseModel = result is null
            ? null
            : new WeatherForecastViewModel(
                result.Id,
                result.Date,
                result.TemperatureC,
                result.TemperatureF,
                result.Summary);

        return result is null
            ? NotFound()
            : Ok(responseModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWeatherForecastAsync(
        [FromRoute] Guid id,
        [FromBody] WeatherForecastUpdateModel model,
        CancellationToken cancellation)
    {
        if (id != model.Id)
            return BadRequest();

        var weathterForecastDto = new WeatherForecastUpdateDto(
            model.Id,
            model.Date,
            model.TemperatureC,
            model.Summary);

        await _weatherForecastsService
            .UpdateWeatherForecastAsync(weathterForecastDto, cancellation);

        return Ok();
    }
}
