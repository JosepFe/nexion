namespace Devon4Net.Infrastructure.Adapters.Repositories;

using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;

public class SurveyRepository : Repository<Survey>, ISurveyRepository
{
    public SurveyRepository(NexionContext context) : base(context)
    {
    }

    public Task<Survey> GetSurveyByIdAsync(ObjectId surveyId) => GetFirstOrDefault(t => t.Id == surveyId);

    public Task<bool> DeleteSurveyByIdAsync(ObjectId surveyId) => Delete(t => t.Id == surveyId);
}
