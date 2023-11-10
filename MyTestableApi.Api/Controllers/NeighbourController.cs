using ChoETL;
using Microsoft.AspNetCore.Mvc;

namespace MyTestableApi.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class NeighbourController : ControllerBase
{
    private readonly ILogger<NeighbourController> _logger;
    public NeighbourController(ILogger<NeighbourController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetNeighbour")]
    public async Task<IActionResult> GetAsync()
    {
        var results = new List<NeighbourModel>();

        using (var reader = new ChoCSVReader(AppDomain.CurrentDomain.BaseDirectory + "../../../country.csv")
            .WithFirstLineHeader().WithDelimiter(";"))
        {
            foreach (var neighbour in reader)
            {
                var result = new NeighbourModel
                {
                    Id = neighbour.Id,
                    Neighbour = neighbour.Neighbour
                };
                results.Add(result);
            }
        }

        if (!results.Any()) return NotFound();
        return Ok(results);

    }

    [HttpGet("{id}", Name = "GetNeighbourById")]
    public async Task<IActionResult> GetAsyncById(string id)
    {
        var results = new List<NeighbourModel>();

        using (var reader = new ChoCSVReader(AppDomain.CurrentDomain.BaseDirectory + "../../../country.csv")
            .WithFirstLineHeader().WithDelimiter(";"))
        {
            foreach (var neighbour in reader)
            {
                var result = new NeighbourModel
                {
                    Id = neighbour.Id,
                    Neighbour = neighbour.Neighbour
                };
                if (result.Neighbour.IsNullOrEmpty()) return NoContent();
                return Ok(result);
            }
        }

        return NotFound();

    }
}
