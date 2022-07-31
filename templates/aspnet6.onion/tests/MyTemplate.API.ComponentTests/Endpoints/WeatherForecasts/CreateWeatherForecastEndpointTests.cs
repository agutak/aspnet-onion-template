using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MyTemplate.API.ComponentTests.Setup;
using System.Net;

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
    [Ignore] // TODO: Remove on real project
    public async Task Get_all_weatherForecasts_returns_ok_Async()
    {
        var response = await _httpClient!.GetAsync("http://localhost:5000/weatherforecasts");
        var result = await response.Content.ReadAsStringAsync();

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    [Ignore] // TODO: Remove on real project
    public async Task Get_specific_weatherForecast_returns_ok_Async()
    {
        var id = new Guid("e0bca7f2-0eaf-4ca8-90d1-bb053abcf6a1");
        var response = await _httpClient!.GetAsync($"http://localhost:5000/weatherforecasts/{id}");
        var result = await response.Content.ReadAsStringAsync();

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsNotNull(result);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _httpClient?.Dispose();
        _webApplicationFactory?.Dispose();
    }
}
