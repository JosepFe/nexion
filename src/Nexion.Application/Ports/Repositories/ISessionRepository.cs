﻿namespace Devon4Net.Application.Ports.Repositories;

using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;

public interface ISessionRepository : IRepository<Session>
{
    Task<Session> GetSessionByIdAsync(ObjectId sessionId);

    Task<bool> DeleteSessionByIdAsync(ObjectId sessionId);
}
