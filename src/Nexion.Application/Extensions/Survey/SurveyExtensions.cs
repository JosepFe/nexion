namespace Nexion.Application.Extensions;

using Devon4Net.Application.Dtos;
using Devon4Net.Domain.Entities;
using Nexion.Application.Dtos;

public static class SurveyExtensions
{
    public static SurveyDto ToSurveyDto(this Survey session)
    {
        return new SurveyDto
        {
            Name = session.Name,
            Description = session.Description,
            Type = session.Type,
            Questions = session.Questions.Select(e => e.ToSurveyQuestionDto()).ToList(),
        };
    }
}
