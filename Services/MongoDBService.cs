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
        return await _workoutsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task CreateAsync(Workout workout)
    {
        await _workoutsCollection.InsertOneAsync(workout);
        return;
    }


}
