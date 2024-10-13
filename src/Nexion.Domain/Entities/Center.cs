namespace Devon4Net.Domain.Entities;

using Devon4Net.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nexion.Domain.Entities;

public class Center : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "center";

    public Center(string? name)
    {
        Name = name;
    }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("location")]
    public Location? Location { get; set; }

    [BsonElement("trainers")]
    public List<ObjectId>? Trainers { get; set; } = [];

    [BsonElement("athletes")]
    public List<ObjectId>? Athletes { get; set; } = [];
}