namespace Devon4Net.Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class SurveyAnswer : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "surveyAnswer";

    [BsonElement("surveyId")]
    public ObjectId SurveyId { get; set; }

    [BsonElement("athelteId")]
    public ObjectId AthelteId { get; set; }

    [BsonElement("answer")]
    public Dictionary<string, string> Answer { get; set; }
}
