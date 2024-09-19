namespace Devon4Net.WebAPI.Controllers;

using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CenterController : ControllerBase
{
    private readonly NexionContext _context;
    private readonly ICenterRepository _centerRepository;
    private readonly ISessionRepository _sessionRepository;

    public CenterController(NexionContext context, ICenterRepository centerRepository, ISessionRepository sessionRepository)
    {
        _context = context;
        _centerRepository = centerRepository;
        _sessionRepository = sessionRepository;
    }

    // GET: api/center/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Center>> GetCenter(string id)
    {
        var trainer = await _context.Sessions!.FirstOrDefaultAsync(c => c.Id.ToString() == id);

        var res = await _centerRepository.Get();
        var res2 = await _sessionRepository.Get();

        if (trainer == null)
        {
            return NotFound();
        }

        return Ok(trainer);
    }
}
