using Devon4Net.Application.Dtos;
using Devon4Net.Infrastructure.Common.Models;
using Devon4Net.Infrastructure.MediatR.Query;
using Nexion.Application.Dtos;

namespace Devon4Net.Application.Features.Queries.GetEmployeeById;

public record GetEmployeeByIdQuery(Guid Id) : QueryBase<DevonResult<EmployeeDto>>;