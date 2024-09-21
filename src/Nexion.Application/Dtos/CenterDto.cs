namespace Devon4Net.Application.Dtos;

public record CenterDto(
    string CenterId,
    string? Name,
    LocationDto? Location,
    List<string> Trainers,
    List<string> Athletes);
