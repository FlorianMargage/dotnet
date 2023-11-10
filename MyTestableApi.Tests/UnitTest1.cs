namespace MyTestableApi.Tests;

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
public class UnitTest1
{
    /*
     * Given : Le pays "est la france"
     * When : Je demande le nombre de population
     * Then : Je récupère le Int de la population en Json
     */
    [Fact]
    public async Task IsGetCountryByIdOk()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Neighbour/Fr");

        Assert.Equal("{\"id\":\"Fr\",\"neighbour\":\"{\\\"Allemagne\\\",\\\"Espagne\\\"}\"}", await response.Content.ReadAsStringAsync());
    }
}