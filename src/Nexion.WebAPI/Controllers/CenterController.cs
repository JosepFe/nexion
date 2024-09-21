namespace Devon4Net.WebAPI.Controllers;

using Devon4Net.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Nexion.Application.Services.Interfaces;

[ApiController]
[Route("/centers")]
public class CenterController : ControllerBase
{
    private readonly ICenterService _centerService;

    public CenterController(ICenterService centerService)
    {
        _centerService = centerService;
    }

    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetCenterById([FromQuery] string centerId)
    {
        var result = await _centerService.GetCenterByIdAsync(centerId);
        return result.BuildResult();
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetCenterById([FromBody] CenterDto centerDto)
    {
        var result = await _centerService.AddCenterAsync(centerDto);
        return result.BuildResult();
    }

    [HttpGet("a")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAllCenters()
    {
        var result = await _centerService.GetAllCentersAsync();
        return result.BuildResult();
    }
}
