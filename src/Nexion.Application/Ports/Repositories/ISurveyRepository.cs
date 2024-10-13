using MongoDB.Bson;

namespace Devon4Net.Application.Ports.Repositories;

using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.UnitOfWork.Repository;

public interface ISurveyRepository : IRepository<Survey>
{
    Task<Survey> GetSurveyByIdAsync(ObjectId surveyId);

    Task<bool> DeleteSurveyByIdAsync(ObjectId surveyId);
}
