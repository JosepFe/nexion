using Devon4Net.Application.Dtos;
using Nexion.Domain.Entities;

namespace Nexion.Application.Extensions;

using Devon4Net.Domain.Entities;
using Nexion.Application.Dtos;

public static class SessionExtensions
{
    public static SessionDto ToSessionDto(this Session session, IList<SurveyDto> surveyDtos)
    {
        return new SessionDto
        {
            SessionId = session.Id.ToString(),
            TrainerId = session.TrainerId.ToString()!,
            SessionType = session.SessionType!,
            SessionExercises = session.Exercises.Select(e => e!.ToSessionExerciseDto()).ToList(),
            Athletes = session.Athletes!.Select(x => x.ToString()).ToList(),
            Surveys = surveyDtos,
        };
    }
}
