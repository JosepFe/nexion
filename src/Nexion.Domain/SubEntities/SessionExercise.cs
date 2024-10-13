using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Domain.Entities;

public class SessionExercise
{
    public SessionExercise(ObjectId exerciseId, int repetitions, int sets)
    {
        ExerciseId = exerciseId;
        Repetitions = repetitions;
        Sets = sets;
    }

    [BsonElement("exerciseId")]
    public ObjectId ExerciseId { get; set; }

    [BsonElement("repetitions")]
    public int Repetitions { get; set; }

    [BsonElement("sets")]
    public int Sets { get; set; }
}
