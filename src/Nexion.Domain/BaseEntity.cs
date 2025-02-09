namespace Nexion.Domain;

using MongoDB.Bson.Serialization.Attributes;

public abstract class BaseEntity<TKey>
{
    [BsonElement("_id")]
    public virtual TKey Id { get; set; }
}
