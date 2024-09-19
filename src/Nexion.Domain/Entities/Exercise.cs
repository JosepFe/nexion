namespace Devon4Net.Domain.Entities;

using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Exercise : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "exercise";

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("muscleGroup")]
    public List<string> MuscleGroup { get; set; }

    [BsonElement("difficulty")]
    public string Difficulty { get; set; }
}
