namespace MyTestableApi.Tests;

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
public class UnitTest1
{
    [Fact]
    public async Task IsGetWeatherForecastOK()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("WeatherForecast");
        string stringResponse = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        // Assert.True(response.IsSuccessStatusCode);
    }
}