using Devon4Net.Application.Dtos;

namespace Nexion.WebAPI.ApiContracts.Center;

public class CenterResponse
{
    public string? CenterId { get; set; }

    public string? Name { get; set; }

    public LocationDto? Location { get; set; }

    public List<string> Trainers { get; set; } = [];

    public List<string> Athletes { get; set; } = [];
}
