﻿namespace Devon4Net.Infrastructure.Adapters.Repositories;

using System.Threading.Tasks;
using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;

public class CenterRepository : Repository<Center>, ICenterRepository
{
    public CenterRepository(NexionContext context) : base(context)
    {
    }

    public Task<Center> GetCenterByIdAsync(ObjectId centerId) => GetFirstOrDefault(t => t.Id == centerId);

    public Task<bool> DeleteCenterByIdAsync(ObjectId centerId) => Delete(t => t.Id == centerId);
}
