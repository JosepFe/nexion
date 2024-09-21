namespace Devon4Net.Application.Dtos;

public record TrainerDto(
    string Name,
    string CenterId, // Reference to Center ID
    List<string> Specialties,
    int Experience);
