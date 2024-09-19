using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Domain.Entities;

public class SessionExercise
{
    [BsonElement("exerciseId")]
    public ObjectId ExerciseId { get; set; }

    [BsonElement("repetitions")]
    public int Repetitions { get; set; }

    [BsonElement("sets")]
    public int Sets { get; set; }
}
