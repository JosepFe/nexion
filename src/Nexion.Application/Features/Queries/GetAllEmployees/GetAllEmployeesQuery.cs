using Devon4Net.Application.Dtos;
using Devon4Net.Infrastructure.MediatR.Query;
using Nexion.Application.Dtos;

namespace Devon4Net.Application.Features.Queries.GetAllEmployees;

public record GetAllEmployeesQuery : QueryBase<IEnumerable<EmployeeDto>>;