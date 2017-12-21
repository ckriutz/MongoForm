using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MongoForm.Web.App_Start
{
    public class MongoContext
    {
        private static MongoClient _client;
        public IMongoDatabase database;
        public IMongoCollection<Models.Survey> Collection;

        public MongoContext() 
        {
            // Reading credentials from Web.config file
            var MongoConnectionString = ConfigurationManager.AppSettings["MongoConnectionString"];

            _client = new MongoClient(MongoConnectionString);

            database = _client.GetDatabase("surveys");
        }

        public bool IsMongoLive()
        {
            if(database != null)
            {
                // Ideally, this will tell us if we can connect to the MongoDB.
                bool isMongoLive = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(5000);

                if(isMongoLive) { return true; };
            }

            return false;
        }

        public int GetCollectionCount(string collectionName)
        {
            var collection = database.GetCollection<Models.Survey>(collectionName);
            var value = collection.CountAsync(new BsonDocument());

            return int.Parse(value.Result.ToString());
        }
    }
}