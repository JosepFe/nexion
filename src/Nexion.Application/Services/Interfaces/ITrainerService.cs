namespace Nexion.Application.Services.Interfaces;

using Devon4Net.Application.Dtos;
using Devon4Net.Infrastructure.Common.Models;
using Nexion.Application.Dtos;

public interface ITrainerService
{
    Task<DevonResult<TrainerDto>> GetTrainerByIdAsync(string trainerId);

    Task<DevonResult<IEnumerable<TrainerDto>>> GetAllTrainersAsync();

    Task<DevonResult<TrainerDto>> AddTrainerAsync(TrainerDto trainerDto);

    Task<DevonResult<bool>> DeleteTrainerAsync(string trainerId);

    Task<DevonResult<TrainerDto>> UpdateTrainerAsync(string trainerId, TrainerDto trainerDto);
}
