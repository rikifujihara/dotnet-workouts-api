using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using workoutsbackend.Models;

namespace workoutsbackend.Services;

public class WorkoutService : IWorkoutService
{
    private readonly WorkoutsDbContext _workoutDbContext;
    public WorkoutService(WorkoutsDbContext workoutsDbContext)
    {
        _workoutDbContext = workoutsDbContext;
    }

    public void AddWorkout(Workout newWorkout)
    {
        _workoutDbContext.Workouts.Add(newWorkout);
        _workoutDbContext.SaveChanges();
    }

    public void DeleteWorkout(Workout workoutToDelete)
    {
        var workout = _workoutDbContext.Workouts.FirstOrDefault((Workout w) => w.Id == workoutToDelete.Id);

        if (workout != null)
        {
            _workoutDbContext.Workouts.Remove(workout);
            _workoutDbContext.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Workout can't be deleted");
        }
    }

    public void EditWorkout(Workout updatedWorkout)
    {
        var workout = _workoutDbContext.Workouts.FirstOrDefault((Workout w) => w.Id == updatedWorkout.Id);

        if (workout != null)
        {
            workout.Name = updatedWorkout.Name;
            _workoutDbContext.Workouts.Update(workout);
            _workoutDbContext.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Couldn't find the workout to update");
        }
    }

    public IEnumerable<Workout> GetAllWorkouts()
    {
        return _workoutDbContext.Workouts.OrderBy((Workout w) => w.Id).AsNoTracking().AsEnumerable();
    }

    public Workout? GetWorkoutById(ObjectId id)
    {
        return _workoutDbContext.Workouts.FirstOrDefault((Workout w) => w.Id == id);
    }
}
