namespace Nexion.Domain.Entities;

using MongoDB.Bson.Serialization.Attributes;

public class SurveyQuestion
{
    public SurveyQuestion(string? name, string? type)
    {
        Name = name;
        Type = type;
    }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("type")]
    public string? Type { get; set; }
}
