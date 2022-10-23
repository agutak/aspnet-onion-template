using MyTemplate.API.ComponentTests.Setup;

namespace MyTemplate.API.ComponentTests.Endpoints.WeatherForecasts;

[TestClass]
[TestCategory("Endpoints/WeatherForecasts")]
public class CreateWeatherForecastEndpointTests
{
    private HttpClient? _httpClient;
    private CustomWebApplicationFactory<Program>? _webApplicationFactory;

    [TestInitialize]
    public void Initialize()
    {
        _webApplicationFactory = new CustomWebApplicationFactory<Program>();
        _httpClient = _webApplicationFactory.CreateClient();
    }

    [TestMethod]
    public async Task Get_all_weatherForecasts_returns_ok_Async()
    {
        // Arrange

        // Act

        // Assert
    }

    [TestMethod]
    [Ignore] // TODO: Remove on real project
    public async Task Get_specific_weatherForecast_returns_ok_Async()
    {
        // Arrange

        // Act

        // Assert
    }

    [TestCleanup]
    public void Cleanup()
    {
        _httpClient?.Dispose();
        _webApplicationFactory?.Dispose();
    }
}
