namespace Devon4Net.Application.Ports.Repositories;

using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;

public interface ITrainerRepository : IRepository<Trainer>
{
    Task<Trainer> GetTrainerByIdAsync(ObjectId trainerId);
    Task<bool> DeleteTrainerByIdAsync(ObjectId trainerId);
}