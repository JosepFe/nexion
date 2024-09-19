namespace Devon4Net.Domain.Entities;

using Devon4Net.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using YourNamespace.Models;

public class Center : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "center";

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("location")]
    public Location Location { get; set; }

    [BsonElement("trainers")]
    public List<string> Trainers { get; set; } // List of trainer IDs

    [BsonElement("athletes")]
    public List<string> Athletes { get; set; } // List of athlete IDs
}