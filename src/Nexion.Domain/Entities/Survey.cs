namespace Devon4Net.Domain.Entities;

using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nexion.Domain.Entities;

public class Survey : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "survey";

    public Survey(string? name, string? description, string? type)
    {
        Name = name;
        Description = description;
        Type = type;
    }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("type")]
    public string? Type { get; set; }

    [BsonElement("questions")]
    public List<SurveyQuestion>? Questions { get; set; } = [];
}
