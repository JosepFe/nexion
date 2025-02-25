namespace Nexion.Application.Ports.Repositories;

using Devon4Net.Infrastructure.UnitOfWork.Repository;
using MongoDB.Bson;
using Nexion.Domain.Entities;

public interface ISurveyRepository : IRepository<Survey>
{
    Task<Survey> GetSurveyByIdAsync(ObjectId surveyId);

    Task<bool> DeleteSurveyByIdAsync(ObjectId surveyId);
}
