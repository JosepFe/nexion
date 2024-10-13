namespace Nexion.WebAPI.ApiContracts.Session;

using Devon4Net.Application.Dtos;
using Nexion.Application.Dtos;

public class SessionBaseInfo
{
    public string TrainerId { get; set; }

    public List<string> Athletes { get; set; } = [];

    public string SessionType { get; set; }

    public List<SessionExerciseDto> SessionExercises { get; set; } = [];

    public List<SurveyDto> Surveys { get; set; } = [];
}
