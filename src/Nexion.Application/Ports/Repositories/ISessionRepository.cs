namespace Nexion.Application.Ports.Repositories;

using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;
using Nexion.Domain.Entities;

public interface ISessionRepository : IRepository<Session>
{
    Task<Session> GetSessionByIdAsync(ObjectId sessionId);

    Task<bool> DeleteSessionByIdAsync(ObjectId sessionId);
}
