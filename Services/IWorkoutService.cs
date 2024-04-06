using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using workoutsbackend.Models;

namespace workoutsbackend.Services;

public interface IWorkoutService
{
    IEnumerable<Workout> GetAllWorkouts();

    Workout? GetWorkoutById(ObjectId id);

    void AddWorkout(Workout newWorkout);

    void EditWorkout(Workout updatedWorkout);

    void DeleteWorkout(Workout workoutToDelete);

}
