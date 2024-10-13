using Nexion.Application.Services.Interfaces;
using Nexion.WebAPI.ApiContracts.Trainer;
using Nexion.WebAPI.Extensions.Trainer;

namespace Devon4Net.WebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/trainers")]
public class TrainerController : ControllerBase
{
    private readonly ITrainerService _trainerService;

    public TrainerController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }

    [HttpGet("{trainerId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetTrainerById([FromRoute] string trainerId)
    {
        var result = await _trainerService.GetTrainerByIdAsync(trainerId);
        return result.BuildResult();
    }

    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAllTrainers()
    {
        var result = await _trainerService.GetAllTrainersAsync();
        return result.BuildResult();
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> CreateTrainer([FromBody] CreateTrainerRequest createTrainerRequest)
    {
        var result = await _trainerService.AddTrainerAsync(createTrainerRequest.ToTrainerDto());
        return result.BuildResult();
    }

    [HttpPut("{trainerId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> UpdateTrainer([FromRoute] string trainerId, [FromBody] UpdateTrainerRequest updateTrainerRequest)
    {
        var result = await _trainerService.UpdateTrainerAsync(trainerId, updateTrainerRequest.ToTrainerDto());
        return result.BuildResult();
    }

    [HttpDelete("{trainerId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteTrainer([FromRoute] string trainerId)
    {
        var result = await _trainerService.DeleteTrainerAsync(trainerId);
        return result.BuildResult();
    }
}
