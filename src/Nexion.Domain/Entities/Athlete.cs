namespace Devon4Net.Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Athlete : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "athlete";

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("age")]
    public int Age { get; set; }

    [BsonElement("centerId")]
    public ObjectId CenterId { get; set; } // Reference to Center ID

    [BsonElement("sports")]
    public List<string> Sports { get; set; }
}
