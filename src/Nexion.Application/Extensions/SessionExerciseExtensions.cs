namespace Nexion.Application.Extensions;

using Devon4Net.Domain.Entities;
using Nexion.Application.Dtos;

public static class SessionExerciseExtensions
{
    public static SessionExerciseDto ToSessionExerciseDto(this SessionExercise sessionExercise)
    {
        return new SessionExerciseDto
        {
            ExerciseId = sessionExercise.ExerciseId.ToString(),
            Repetitions = sessionExercise.Repetitions,
            Sets = sessionExercise.Sets,
        };
    }
}
