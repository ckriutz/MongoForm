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
        private MongoDB.Driver.IMongoCollection<Models.Survey> _collection;

        public SurveyController()
        {
            App_Start.MongoContext mongoContext = new App_Start.MongoContext();

            _collection = mongoContext.database.GetCollection<Models.Survey>("Survey");
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
            _collection.InsertOne(survey);
            var list = GetAllSurveys();
            return View("Index", list);
        }

        public ActionResult Delete(string id)
        {
            ObjectId oid = ObjectId.Parse(id);
            var deleted = _collection.DeleteOne(d => d.Id == oid);

            return RedirectToAction("Index");
        }

        private List<Models.Survey> GetAllSurveys()
        {
            List<Models.Survey> SurveysList = new List<Models.Survey>();
            var docs = _collection.Find(FilterDefinition<Models.Survey>.Empty).ToListAsync();
            SurveysList = docs.Result;

            return SurveysList;
        }
    }
}