namespace Devon4Net.Infrastructure.Adapters.Repositories;

using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;
using System.Threading.Tasks;

public class CenterRepository : Repository<Center>, ICenterRepository
{
    public CenterRepository(NexionContext context) : base(context)
    {
    }

    public Task<Center> GetCenterByIdAsync(ObjectId id)
    {
        return GetFirstOrDefault(t => t.Id == id);
    }
}
