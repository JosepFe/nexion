namespace Devon4Net.Infrastructure.Adapters.Repositories;

using System.Threading.Tasks;
using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;

public class TrainerRepository : Repository<Trainer>, ITrainerRepository
{
    public TrainerRepository(NexionContext context) : base(context)
    {
    }

    public Task<Trainer> GetTrainerByIdAsync(ObjectId trainerId) => GetFirstOrDefault(t => t.Id == trainerId);

    public Task<bool> DeleteTrainerByIdAsync(ObjectId trainerId) => Delete(t => t.Id == trainerId);
}
