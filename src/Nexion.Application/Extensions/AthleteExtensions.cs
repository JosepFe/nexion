namespace Nexion.Application.Extensions;

using Devon4Net.Application.Dtos;
using Devon4Net.Domain.Entities;

public static class AthleteExtensions
{
    public static AthleteDto ToAthleteDto(this Athlete athlete)
    {
        return new AthleteDto
        {
            Name = athlete.Name,
            Age = athlete.Age,
            CenterId = athlete.CenterId.ToString(), // Assuming CenterId is a string, handle ObjectId if necessary
            Sports = athlete.Sports,
        };
    }
}