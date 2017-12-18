using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoForm.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            App_Start.MongoContext mongoContext = new App_Start.MongoContext();

            ViewBag.IsMongoLive = mongoContext.IsMongoLive();
            ViewBag.DocumentCount = mongoContext.GetCollectionCount("Survey");
            return View();
        }
    }
}