namespace Devon4Net.Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class AthleteSession
{
    [BsonElement("athleteId")]
    public ObjectId AthleteId { get; set; }

    [BsonElement("surveys")]
    public List<Survey> Surveys { get; set; }
}
