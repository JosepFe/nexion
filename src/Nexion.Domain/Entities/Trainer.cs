namespace Nexion.Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Trainer : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "trainer";

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("centerId")]
    public ObjectId? CenterId { get; set; }

    [BsonElement("specialties")]
    public List<string>? Specialties { get; set; }

    [BsonElement("experience")]
    public int? Experience { get; set; }
}
