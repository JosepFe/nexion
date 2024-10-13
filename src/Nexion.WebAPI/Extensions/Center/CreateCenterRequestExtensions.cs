namespace Nexion.WebAPI.Extensions.Center;

using Devon4Net.Application.Dtos;
using Nexion.WebAPI.ApiContracts.Center;

public static class CreateCenterRequestExtensions
{
    public static CenterDto ToCenterDto(this CreateCenterRequest createCenterRequest) => new()
    {
        Name = createCenterRequest.Name,
        Location = createCenterRequest.Location,
    };
}
