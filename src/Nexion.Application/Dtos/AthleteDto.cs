namespace Devon4Net.Application.Dtos;

public class AthleteDto
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string? CenterId { get; set; }

    public List<string> Sports { get; set; } = [];
}
