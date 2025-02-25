using Nexion.Application.Ports.Repositories;
using Nexion.Domain.Entities;
using Nexion.Infrastructure.Persistence;

namespace Nexion.Infrastructure.Adapters.Repositories;

using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;

public class AthleteRepository : Repository<Athlete>, IAthleteRepository
{
    public AthleteRepository(NexionContext context)
        : base(context)
    {
    }

    public Task<Athlete> GetAthleteByIdAsync(ObjectId athleteId) => GetFirstOrDefault(t => t.Id == athleteId);

    public Task<bool> DeleteAthleteByIdAsync(ObjectId athleteId) => Delete(t => t.Id == athleteId);
}