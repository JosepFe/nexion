namespace Devon4Net.Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class PredefinedQuestion : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "predefinedQuestion";

    [BsonElement("text")]
    public string Text { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }
}
