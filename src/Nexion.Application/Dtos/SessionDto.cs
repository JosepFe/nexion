namespace Nexion.Application.Dtos;

using Devon4Net.Application.Dtos;

public class SessionDto
{
    public string? SessionId { get; set; }

    public string? TrainerId { get; set; }

    public IList<string>? Athletes { get; set; }

    public string? SessionType { get; set; }

    public IList<SessionExerciseDto>? SessionExercises { get; set; }

    public IList<SurveyDto>? Surveys { get; set; }
}