using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using workoutsbackend.Models;

namespace workoutsbackend.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Workout> _workoutsCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _workoutsCollection = database.GetCollection<Workout>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Workout>> GetAsync()
    {
        var sort = Builders<Workout>.Sort.Descending(w => w.Timestamp);
        return await _workoutsCollection.Find(new BsonDocument()).Sort(sort).ToListAsync();
    }

    public async Task CreateAsync(Workout workout)
    {
        await _workoutsCollection.InsertOneAsync(workout);
        return;
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Workout> filter = Builders<Workout>.Filter.Eq("Id", id);
        await _workoutsCollection.DeleteOneAsync(filter);
        return;
    }

    public async Task ReplaceAsync(string id, Workout workout)
    {
        // Filter to find the workout with matching id
        FilterDefinition<Workout> filter = Builders<Workout>.Filter.Eq("Id", id);

        // Replace the matching workout with the new workout
        await _workoutsCollection.ReplaceOneAsync(filter, workout);
        return;
    }
}
