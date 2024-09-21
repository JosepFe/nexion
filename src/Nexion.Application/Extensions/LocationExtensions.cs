namespace Nexion.Application.Extensions;

using Devon4Net.Application.Dtos;
using Devon4Net.Domain.Entities;
using Nexion.Domain.Entities;

public static class LocationExtensions
{
    public static LocationDto? ToLocationDto(this Location location)
    {
        return new LocationDto(
            location.Address,
            location.City,
            location.State,
            location.ZipCode,
            location.Country
        );
    }
}
