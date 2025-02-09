namespace Nexion.Application.Dtos;

public class AthleteDto
{
    public string? AthleteId { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public List<string> Sports { get; set; } = [];
}
