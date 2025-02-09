namespace Nexion.WebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Nexion.Application.Services.Interfaces;
using Nexion.WebAPI.ApiContracts.Athlete;
using Nexion.WebAPI.Extensions.Athlete;

[ApiController]
[Route("/athletes")]
public class AthleteController : ControllerBase
{
    private readonly IAthleteService _athleteService;

    public AthleteController(IAthleteService athleteService)
    {
        _athleteService = athleteService;
    }

    [HttpGet("{athleteId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAthleteById([FromRoute] string athleteId)
    {
        var result = await _athleteService.GetAthleteByIdAsync(athleteId);
        return result.BuildResult();
    }

    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAllAthletes()
    {
        var result = await _athleteService.GetAllAthletesAsync();
        return result.BuildResult();
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> CreateAthlete([FromBody] CreateAthleteRequest createAthleteRequest)
    {
        var result = await _athleteService.AddAthleteAsync(createAthleteRequest.ToAthleteDto());
        return result.BuildResult();
    }

    [HttpPut("{athleteId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> UpdateAthlete([FromRoute] string athleteId, [FromBody] UpdateAthleteRequest updateAthleteRequest)
    {
        var result = await _athleteService.UpdateAthleteAsync(athleteId, updateAthleteRequest.ToAthleteDto());
        return result.BuildResult();
    }

    [HttpDelete("{athleteId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteAthlete([FromRoute] string athleteId)
    {
        var result = await _athleteService.DeleteAthleteAsync(athleteId);
        return result.BuildResult();
    }
}
