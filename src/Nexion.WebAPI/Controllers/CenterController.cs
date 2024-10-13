namespace Devon4Net.WebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Nexion.Application.Extensions;
using Nexion.Application.Services.Interfaces;
using Nexion.WebAPI.ApiContracts.Center;
using Nexion.WebAPI.Extensions.Center;

[ApiController]
[Route("/centers")]
public class CenterController : ControllerBase
{
    private readonly ICenterService _centerService;

    public CenterController(ICenterService centerService)
    {
        _centerService = centerService;
    }

    [HttpGet("{centerId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetCenterById([FromRoute] string centerId)
    {
        var result = await _centerService.GetCenterByIdAsync(centerId);
        return result.BuildResult();
    }

    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAllCenters()
    {
        var result = await _centerService.GetAllCentersAsync();
        return result.BuildResult();
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> CreateCenter([FromBody] CreateCenterRequest createCenterRequest)
    {
        var result = await _centerService.AddCenterAsync(createCenterRequest.ToCenterDto());
        return result.BuildResult();
    }

    [HttpDelete("{centerId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteCenter([FromRoute] string centerId)
    {
        var result = await _centerService.DeleteCenterAsync(centerId);
        return result.BuildResult();
    }
}
