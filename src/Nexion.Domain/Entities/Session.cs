namespace Devon4Net.Domain.Entities;

using System.Collections.Generic;
using Devon4Net.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Session : BaseEntity<ObjectId>
{
    public static readonly string CollectionName = "session";

    [BsonElement("trainerId")]
    public ObjectId TrainerId { get; set; }

    [BsonElement("athletes")]
    public List<AthleteSession> Athletes { get; set; }

    [BsonElement("sessionType")]
    public string SessionType { get; set; }

    [BsonElement("exercises")]
    public List<SessionExercise> Exercises { get; set; }
}
