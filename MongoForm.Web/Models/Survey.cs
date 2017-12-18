using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoForm.Web.Models
{
    public class Survey
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Satisfaction")]
        public int Satisfaction { get; set; }

        [BsonElement("WasHelped")]
        public bool IsWasHelped { get; set; }

        [BsonElement("Comments")]
        public string Comments { get; set; }
    }
}