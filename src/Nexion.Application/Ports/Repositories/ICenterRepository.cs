namespace Devon4Net.Application.Ports.Repositories;

using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;

public interface ICenterRepository: IRepository<Center>
{
    Task<Center> GetCenterByIdAsync(ObjectId centerId);
    Task<bool> DeleteCenterByIdAsync(ObjectId centerId);
}