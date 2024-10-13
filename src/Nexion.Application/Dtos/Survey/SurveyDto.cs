namespace Devon4Net.Application.Dtos;

public class SurveyDto()
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public List<SurveyQuestionDto> Questions { get; set; } = [];
}
