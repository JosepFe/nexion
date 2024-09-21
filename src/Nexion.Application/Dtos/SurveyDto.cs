namespace Devon4Net.Application.Dtos;

public record SurveyDto(
    string SurveyId,
    List<SurveyQuestionDto> Questions);
