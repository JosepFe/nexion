using Devon4Net.Application.Dtos;
using Devon4Net.Infrastructure.MediatR.Command;
using Nexion.Application.Dtos;

namespace Devon4Net.Application.Features.Command.CreateEmployee;

public record CreateEmployeeCommand(string? Name, string? Surname, string? Mail) : CommandBase<EmployeeDto>;