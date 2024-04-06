using Microsoft.EntityFrameworkCore;
using workoutsbackend.Models;

namespace workoutsbackend.Services;

public class WorkoutsDbContext : DbContext
{
    public DbSet<Workout> Workouts { get; set; }

    public WorkoutsDbContext(DbContextOptions options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Workout>();
    }
}
