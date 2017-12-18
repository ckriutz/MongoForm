using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MongoForm.Web.Controllers
{
    public class SurveyController : Controller
    {
        private MongoDB.Driver.IMongoCollection<BsonDocument> _collection;
        public SurveyController()
        {
            App_Start.MongoContext mongoContext = new App_Start.MongoContext();

            _collection = mongoContext.database.GetCollection<BsonDocument>("Survey");
        }

        // GET: Survey
        public ActionResult Index()
        {
            var list = GetAllSurveys();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Survey survey)
        {
            _collection.InsertOne(survey.ToBsonDocument());
            var list = GetAllSurveys();
            return View("Index", list);
        }

        public ActionResult Delete(string id)
        {
            //deleting single record

            var deleted = _collection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", 140));
            var results = deleted.Result;

            return RedirectToAction("Index");
        }

        private List<Models.Survey> GetAllSurveys()
        {
            List<Models.Survey> SurveysList = new List<Models.Survey>();
            var docs = _collection.Find(new BsonDocument()).ToListAsync();
            var results = docs.Result;

            foreach(BsonDocument doc in results)
            {
                var surveyObj = BsonSerializer.Deserialize<Models.Survey>(doc);
                SurveysList.Add(surveyObj);
            }
            return SurveysList;
        }
    }
}