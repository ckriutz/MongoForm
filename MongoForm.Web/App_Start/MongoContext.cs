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
        public IMongoDatabase Database;
        public IMongoCollection<Models.Survey> Collection;

        public MongoContext() 
        {
            // Reading credentials from Web.config file
            var MongoConnectionString = ConfigurationManager.AppSettings["MongoConnectionString"];

            _client = new MongoClient(MongoConnectionString);

            //Database = _client.GetDatabase("foo");

            //var collection = Database.GetCollection<BsonDocument>("bar");

        }
    }
}