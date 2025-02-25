namespace Nexion.WebAPI.Extensions.Athlete;

using Nexion.Application.Dtos;
using Nexion.WebAPI.ApiContracts.Athlete;

public static class AthleteExtensions
{
    public static AthleteDto ToAthleteDto(this CreateAthleteRequest request)
    {
        return new AthleteDto
        {
            Name = request.Name,
            Age = request.Age,
            Sports = request.Sports,
        };
    }

    public static AthleteDto ToAthleteDto(this UpdateAthleteRequest request)
    {
        return new AthleteDto
        {
            Name = request.Name,
            Age = request.Age,
            Sports = request.Sports,
        };
    }
}
