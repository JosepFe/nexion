using System.Linq.Expressions;

namespace Devon4Net.Infrastructure.Adapters.Repositories;

using System.Threading.Tasks;
using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;

public class SessionRepository : Repository<Session>, ISessionRepository
{
    public SessionRepository(NexionContext context) : base(context)
    {
    }

    public Task<Session> GetSessionByIdAsync(ObjectId sessionId) => GetFirstOrDefault(t => t.Id == sessionId);

    public Task<bool> DeleteSessionByIdAsync(ObjectId sessionId) => Delete(t => t.Id == sessionId);

    public async Task<IList<Session>> GetSessionsByAthleteIdAsync(string athleteId)
    {
        var athleteObjectId = new ObjectId(athleteId);

        // Define the predicate to filter by athleteId in the athletes array
        Expression<Func<Session, bool>> predicate = session => session.Athletes.Contains(athleteObjectId);

        // Use the existing Get method to retrieve the sessions
        return await Get(predicate);
    }
}
