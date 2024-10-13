namespace Nexion.Application.Extensions;

using Devon4Net.Domain.Entities;
using Nexion.Application.Dtos;

public static class ExerciseExtensions
{
    // Convert Exercise entity to ExerciseDto
    public static ExerciseDto ToExerciseDto(this Exercise exercise)
    {
        return new ExerciseDto
        {
            ExerciseId = exercise.Id.ToString(),
            Name = exercise.Name,
            Description = exercise.Description,
            MuscleGroup = exercise.MuscleGroup,
            Difficulty = exercise.Difficulty,
        };
    }
}