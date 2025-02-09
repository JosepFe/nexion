namespace Nexion.Application.Ports.Repositories;

using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;
using Nexion.Domain.Entities;

public interface ITrainerRepository : IRepository<Trainer>
{
    Task<Trainer> GetTrainerByIdAsync(ObjectId trainerId);

    Task<bool> DeleteTrainerByIdAsync(ObjectId trainerId);
}