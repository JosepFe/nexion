namespace Nexion.Application.Dtos;

public class TrainerDto
{
    public string? TrainerId { get; set; }

    public string? Name { get; set; }

    public List<string>? Specialties { get; set; } = [];

    public int? Experience { get; set; }
}
