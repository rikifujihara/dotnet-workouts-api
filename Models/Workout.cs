using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace workoutsbackend.Models;

[Collection("workouts")]
public class Workout
{
    public ObjectId Id { get; set; }

    [Required(ErrorMessage = "Workout needs a name")]
    [Display(Name = "Name")]
    public string? Name { get; set; }

}
