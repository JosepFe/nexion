namespace Devon4Net.Infrastructure.Adapters.Repositories;

using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.Repository;

public class AthleteRepository : Repository<Athlete>, IAthleteRepository
{
    public AthleteRepository(NexionContext context) : base(context)
    {
    }
}
