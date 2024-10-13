namespace Nexion.Application.Services.Interfaces;

using Devon4Net.Infrastructure.Common.Models;
using Nexion.Application.Dtos;

public interface ISessionService
{
    Task<DevonResult<SessionDto>> AddSessionAsync(SessionDto sessionDto);

    Task<DevonResult<SessionDto>> GetSessionByIdAsync(string sessionId);
    
    Task<DevonResult<IEnumerable<SessionDto>>> GetAllSessionsAsync();
    
    Task<DevonResult<SessionDto>> UpdateSessionAsync(string sessionId, SessionDto sessionDto);
    
    Task<DevonResult<bool>> DeleteSessionAsync(string sessionId);
}
