namespace Nexion.Application.Services.Interfaces;

using Devon4Net.Application.Dtos;
using Devon4Net.Infrastructure.Common.Models;
using Nexion.Application.Dtos;

public interface IAthleteService
{
    Task<DevonResult<AthleteDto>> AddAthleteAsync(AthleteDto athleteDto);

    Task<DevonResult<bool>> DeleteAthleteAsync(string athleteId);

    Task<DevonResult<IEnumerable<AthleteDto>>> GetAllAthletesAsync();

    Task<DevonResult<AthleteDto>> GetAthleteByIdAsync(string athleteId);

    Task<DevonResult<AthleteDto>> UpdateAthleteAsync(string athleteId, AthleteDto athleteDto);
}