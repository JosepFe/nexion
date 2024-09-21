namespace Devon4Net.Application.Dtos;

public record ExerciseDto(
    string Name,
    string Description,
    List<string> MuscleGroup,
    string Difficulty);
