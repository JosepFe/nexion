namespace Nexion.WebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Nexion.Application.Services.Interfaces;
using Nexion.WebAPI.ApiContracts.Session;
using Nexion.WebAPI.Extensions.Session;

[ApiController]
[Route("/sessions")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpGet("{sessionId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetSessionById([FromRoute] string sessionId)
    {
        var result = await _sessionService.GetSessionByIdAsync(sessionId);
        return result.BuildResult();
    }
    
    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAllSessions()
    {
        var result = await _sessionService.GetAllSessionsAsync();
        return result.BuildResult();
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> CreateSession([FromBody] CreateSessionRequest createSessionRequest)
    {
        var result = await _sessionService.AddSessionAsync(createSessionRequest.ToSessionDto());
        return result.BuildResult();
    }

    [HttpPut("{sessionId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> UpdateSession([FromRoute] string sessionId, [FromBody] UpdateSessionRequest updateSessionRequest)
    {
        var result = await _sessionService.UpdateSessionAsync(sessionId, updateSessionRequest.ToSessionDto());
        return result.BuildResult();
    }
    
    [HttpDelete("{sessionId}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> DeleteSession([FromRoute] string sessionId)
    {
        var result = await _sessionService.DeleteSessionAsync(sessionId);
        return result.BuildResult();
    }
}
