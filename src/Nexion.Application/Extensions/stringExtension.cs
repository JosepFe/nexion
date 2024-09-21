using MongoDB.Bson;

namespace Nexion.Application.Extensions;

public static class stringExtension
{
    /// <summary>
    /// Converts a string to ObjectId if valid; otherwise, returns null.
    /// </summary>
    /// <param name="id">The string representation of ObjectId</param>
    /// <returns>ObjectId if valid, null if invalid</returns>
    public static ObjectId? ToObjectId(this string id)
    {
        if (ObjectId.TryParse(id, out var objectId))
        {
            return objectId;
        }
        return null;
    }
}
