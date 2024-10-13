namespace Nexion.Application.Extensions;

using Devon4Net.Application.Dtos;
using Nexion.Domain.Entities;

public static class SurveyQuestionExtensions
{
    public static SurveyQuestionDto ToSurveyQuestionDto(this SurveyQuestion session)
    {
        return new SurveyQuestionDto
        {
            Name = session.Name,
            Type = session.Type,
        };
    }
}
