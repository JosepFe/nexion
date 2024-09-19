using MongoDB.Bson.Serialization.Attributes;

namespace YourNamespace.Models
{
    public class Location
    {
        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("zipCode")]
        public string ZipCode { get; set; }
    }
}
