namespace Nexion.Application.Extensions;

using Nexion.Application.Dtos;
using Nexion.Domain.Entities;

public static class TrainerExtensions
{
    public static TrainerDto ToTrainerDto(this Trainer trainer)
    {
        return new TrainerDto
        {
            TrainerId = trainer.Id.ToString(),
            Name = trainer.Name,
            Specialties = trainer.Specialties,
            Experience = trainer.Experience,
        };
    }
}
