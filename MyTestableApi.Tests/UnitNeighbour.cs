namespace MyTestableApi.Tests;

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
public class Country
{
    [Fact]
    public async Task CountryFound()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("NeighbourModel");
        string stringResponse = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        // Assert.True(response.IsSuccessStatusCode);
    }
}