namespace Devon4Net.Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class Survey
{
    [BsonElement("surveyId")]
    public ObjectId SurveyId { get; set; }

    [BsonElement("questions")]
    public List<SurveyQuestion> Questions { get; set; }
}
