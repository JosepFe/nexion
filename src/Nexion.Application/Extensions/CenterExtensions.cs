namespace Nexion.Application.Extensions;

using Devon4Net.Application.Dtos;
using Devon4Net.Domain.Entities;

public static class CenterExtensions
{
    public static CenterDto ToCenterDto(this Center center)
    {
        return new CenterDto(
            CenterId: center.Id.ToString(),
            Name: center.Name,
            Location: center.Location.ToLocationDto(),
            Trainers: center.Trainers?.Select(trainerId => trainerId.ToString()).ToList() ?? [],
            Athletes: center.Athletes?.Select(athleteId => athleteId.ToString()).ToList() ?? []
        );
    }
}
