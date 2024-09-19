namespace Devon4Net.Infrastructure.Adapters;

using Devon4Net.Application.Ports;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.UnitOfWork;

public class NexionUoW : UnitOfWork<NexionContext>, INexionUoW
{
    public NexionUoW(NexionContext context) : base(context)
    {
    }
}