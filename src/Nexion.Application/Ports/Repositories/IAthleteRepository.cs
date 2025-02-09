namespace Nexion.Application.Ports.Repositories;

using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;
using Nexion.Domain.Entities;

public interface IAthleteRepository : IRepository<Athlete>
{
    Task<Athlete> GetAthleteByIdAsync(ObjectId athleteId);

    Task<bool> DeleteAthleteByIdAsync(ObjectId athleteId);
}
