namespace Nexion.Application.Dtos;

public class ExerciseDto
{
    public string ExerciseId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<string> MuscleGroup { get; set; }

    public string Difficulty { get; set; }
}
