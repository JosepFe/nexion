namespace Nexion.WebAPI.ApiContracts.Center;

using Devon4Net.Application.Dtos;

public class CreateCenterRequest
{
    public string? Name { get; set; }

    public LocationDto? Location { get; set; }
}
