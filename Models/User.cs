using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace workoutsbackend;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required]
    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

}
