using Nexion.Application.Dtos;
using Nexion.Domain.Entities;

namespace Nexion.Application.Extensions;

using Devon4Net.Application.Dtos;
using Devon4Net.Domain.Entities;

public static class AthleteExtensions
{
    public static AthleteDto ToAthleteDto(this Athlete athlete)
    {
        return new AthleteDto
        {
            AthleteId = athlete.Id.ToString(),
            Name = athlete.Name,
            Age = athlete.Age,
            Sports = athlete.Sports,
        };
    }
}
