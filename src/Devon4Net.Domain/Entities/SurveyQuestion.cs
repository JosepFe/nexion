namespace Devon4Net.Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class SurveyQuestion
{
    [BsonElement("questionId")]
    public ObjectId QuestionId { get; set; }

    [BsonElement("answer")]
    public string Answer { get; set; }
}
