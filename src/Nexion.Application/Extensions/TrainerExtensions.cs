namespace Nexion.Application.Extensions;

using Devon4Net.Application.Dtos;
using Devon4Net.Domain.Entities;

public static class TrainerExtensions
{
    public static TrainerDto ToTrainerDto(this Trainer trainer)
    {
        return new TrainerDto
        {
            TrainerId = trainer.Id.ToString(),
            Name = trainer.Name,
            CenterId = trainer.CenterId.ToString(),
            Specialties = trainer.Specialties,
            Experience = trainer.Experience,
        };
    }
}
