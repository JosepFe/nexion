﻿using Nexion.Application.Ports.Repositories;
using Nexion.Domain.Entities;
using Nexion.Infrastructure.Persistence;

namespace Devon4Net.Infrastructure.Adapters.Repositories;

using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Persistence;
using Devon4Net.Infrastructure.UnitOfWork.Repository;

public class SurveyAnswerRepository : Repository<SurveyAnswer>, ISurveyAnswerRepository
{
    public SurveyAnswerRepository(NexionContext context) : base(context)
    {
    }
}
