using CookApp.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CookApp.API.Data
{
    public class MongoDBDataContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBDataContext(IOptions<MongoDBSettings> settings)
        {
                var client = new MongoClient(settings.Value.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(settings.Value.Database);
        }


        public IMongoCollection<Worker> Workers
        {
        get
        {
            return _database.GetCollection<Worker>("Recipes");
        }
        }


    }
}