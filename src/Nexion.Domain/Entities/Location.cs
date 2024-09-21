namespace Nexion.Domain.Entities;

using MongoDB.Bson.Serialization.Attributes;

public class Location
{
    public Location(string? address, string? city, string? state, string? zipCode, string? country)
    {
        Address = address;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
    }

    [BsonElement("address")]
    public string? Address { get; set; }

    [BsonElement("city")]
    public string? City { get; set; }

    [BsonElement("state")]
    public string? State { get; set; }

    [BsonElement("zipCode")]
    public string? ZipCode { get; set; }

    [BsonElement("country")]
    public string? Country { get; set; }
}
