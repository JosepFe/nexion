namespace Nexion.WebAPI.Extensions.Trainer;

using Nexion.Application.Dtos;
using Nexion.WebAPI.ApiContracts.Trainer;

public static class TrainerExtensions
{
    public static TrainerDto ToTrainerDto(this CreateTrainerRequest request)
    {
        return new TrainerDto
        {
            Name = request.Name,
            Experience = request.Experience,
            Specialties = request.Specialties,
        };
    }

    public static TrainerDto ToTrainerDto(this UpdateTrainerRequest request)
    {
        return new TrainerDto
        {
            Name = request.Name,
            Experience = request.Experience,
            Specialties = request.Specialties,
        };
    }
}
