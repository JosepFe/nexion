namespace Devon4Net.Application.Dtos;

public record AthleteDto(
    string Name,
    int Age,
    string CenterId,
    List<string> Sports);
