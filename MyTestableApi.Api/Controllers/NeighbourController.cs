using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace MyTestableApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NeighbourController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<NeighbourController> _logger;

    public NeighbourController(ILogger<NeighbourController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetNeighbour")]
    public IEnumerable<WeatherForecast> Get()
    {
        using (var reader = new StringReader(@"../data.json")) ;
    }
}
