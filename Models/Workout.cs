using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace workoutsbackend.Models;

public class Workout
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public int Reps { get; set; }

    [Required]
    public int Load { get; set; }
}
