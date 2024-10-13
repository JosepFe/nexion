using Devon4Net.Application.Dtos;
using Devon4Net.Infrastructure.Common.Models;

namespace Nexion.Application.Services.Interfaces;

public interface ICenterService
{
    Task<DevonResult<CenterDto>> GetCenterByIdAsync(string centerId);

    Task<DevonResult<IEnumerable<CenterDto>>> GetAllCentersAsync();

    Task<DevonResult<CenterDto>> AddCenterAsync(CenterDto centerDto);

    Task UpdateCenterAsync(string id, CenterDto centerDto);

    Task<DevonResult<bool>> DeleteCenterAsync(string centerId);
}
