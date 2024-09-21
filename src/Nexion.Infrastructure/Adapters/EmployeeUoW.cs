namespace Devon4Net.Infrastructure.Adapters;

using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.UnitOfWork;
using Nexion.Application.Ports.UoW;

public class EmployeeUoW : UnitOfWork<EmployeeContext>, IEmployeeUoW
{
    public EmployeeUoW(EmployeeContext context) : base(context)
    {
    }
}