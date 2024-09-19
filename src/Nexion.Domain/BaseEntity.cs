using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Domain;

public abstract class BaseEntity<TKey>
{
    [BsonElement("_id")]
    public virtual TKey Id { get; set; }
}
